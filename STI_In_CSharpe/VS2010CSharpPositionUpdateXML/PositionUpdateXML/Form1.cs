/* 
 * Solely as an accommodation to Subscriber, Sterling has agreed to provide sample source code (“Code”) 
 * to demonstrate how Subscriber might be able to develop its own software code to facilitate Subscriber’s 
 * interaction with the Sterling front-end modules via Sterling’s Application Programming Interface (API).  
 * Sterling is providing the Code “as is”, and Sterling has no obligation to provide any updates, revisions, 
 * modifications or enhancements to the Code.  Sterling is not writing or assisting in writing Subscriber’s 
 * code, and consequently Sterling has no responsibility or liability for Subscriber’s use or modification 
 * of the Code.  
 * 
 * STERLING EXPRESSLY DISCLAIMS ALL REPRESENTATIONS AND WARRANTIES, EXPRESS OR IMPLIED, WITH RESPECT TO 
 * THE CODE, INCLUDING THE WARRANTIES OF MERCHANTABILITY AND OF FITNESS FOR A PARTICULAR PURPOSE. 
 * UNDER NO CIRCUMSTANCES INCLUDING NEGLIGENCE SHALL STERLING BE LIABLE FOR ANY DAMAGES, INCIDENTAL, 
 * SPECIAL, CONSEQUENTIAL OR OTHERWISE (INCLUDING WITHOUT LIMITATION DAMAGES FOR LOSS OF PROFITS, 
 * BUSINESS INTERRUPTION, LOSS OF INFORMATION OR OTHER PECUNIARY LOSS) THAT MAY RESULT FROM THE USE OF 
 * OR INABILITY TO USE THE CODE, EVEN IF STERLING HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO; 

namespace PositionUpdateXML
{
    public partial class Form1 : Form
    {
        private SterlingLib.STIApp stiApp = new SterlingLib.STIApp();
        private SterlingLib.STIEvents stiEvents = new SterlingLib.STIEvents();
        private SterlingLib.STIOrder stiOrder = new SterlingLib.STIOrder();
        private SterlingLib.STIPosition stiPos = new SterlingLib.STIPosition();
        private SterlingLib.STIQuote stiQuote = new SterlingLib.STIQuote();
        private List<string> listMsg = new List<string>();

        private bool bModeXML = true;

        [StructLayout(LayoutKind.Sequential)]

        public class SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayofWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public class LibWrap 
        {
            [DllImport("Kernel32.dll")]
            public static extern void GetSystemTime([In, Out] SYSTEMTIME st);        
        }

        public Form1()
        {
            stiPos.DeRegisterPositions();
            listMsg.Clear();
            InitializeComponent();
            stiApp.SetModeXML(bModeXML);
            stiEvents.SetOrderEventsAsStructs(true);
            stiPos.OnSTIPositionUpdateXML += new SterlingLib._ISTIPositionEvents_OnSTIPositionUpdateXMLEventHandler(OnSTIPositionUpdateXML);
            stiPos.RegisterForPositions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stiQuote.RegisterQuote("RIMM", "");
            stiOrder.Symbol = "RIMM";
            stiOrder.Account = "DEMFREDDY";
            stiOrder.Side = "B";
            stiOrder.Quantity = 100;
            stiOrder.Destination = "EDGA";
            stiOrder.Tif = "D";
            stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTIMkt;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = "DEMFREDDY" + st.wYear + st.wMonth + st.wDayofWeek + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int order = stiOrder.SubmitOrder();
            if (order !=0){
                Console.WriteLine("Order Error :" + order.ToString());
            }
        }

       private void OnSTIPositionUpdateXML(ref string strPosition) 
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIPositionUpdate));
            SterlingLib.structSTIPositionUpdate structPosition = (SterlingLib.structSTIPositionUpdate)xs.Deserialize(new StringReader(strPosition));
            int netPos = (structPosition.nSharesBot - structPosition.nSharesSld);
            AddListBoxItem("Postion (XML):  " + structPosition.bstrSym + "  Position =  " + netPos);
        }

        public delegate void AddListBoxItemDelegate(object structQuote);

        private void AddListBoxItem(object structPosition) {
            if (InvokeRequired)
            {
                this.listBox1.Invoke(new AddListBoxItemDelegate(AddListBoxItem), structPosition);
            }
            else
                listBox1.Items.Add(structPosition);
    
            }
  

    }
}


