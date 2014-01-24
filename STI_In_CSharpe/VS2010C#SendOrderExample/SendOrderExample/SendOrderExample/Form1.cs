//CODE DISCLAIMER
//Solely as an accommodation to Subscriber, Sterling has agreed to provide sample source code
//("Code") to demonstrate how Subscriber might be able to develop its own software code to
//facilitate Subscriber's interaction with the Sterling front-end modules via Sterling's Application
//Programming Interface (API).  Sterling is providing the Code "as is", and Sterling has no obligation to
//provide any updates, revisions, modifications or enhancements to the Code.  Sterling is not writing
//or assisting in writing Subscriber's code, and consequently Sterling has no responsibility or liability
//for Subscriber's use or modification of the Code.  STERLING EXPRESSLY DISCLAIMS ALL
//REPRESENTATIONS AND WARRANTIES, EXPRESS OR IMPLIED, WITH RESPECT
//TO THE CODE, INCLUDING THE WARRANTIES OF MERCHANTABILITY AND OF
//FITNESS FOR A PARTICULAR PURPOSE. UNDER NO CIRCUMSTANCES
//INCLUDING NEGLIGENCE SHALL STERLING BE LIABLE FOR ANY DAMAGES,
//INCIDENTAL, SPECIAL, CONSEQUENTIAL OR OTHERWISE (INCLUDING WITHOUT
//LIMITATION DAMAGES FOR LOSS OF PROFITS, BUSINESS INTERRUPTION, LOSS
//OF INFORMATION OR OTHER PECUNIARY LOSS) THAT MAY RESULT FROM THE
//USE OF OR INABILITY TO USE THE CODE, EVEN IF STERLING HAS BEEN ADVISED
//OF THE POSSIBILITY OF SUCH DAMAGES.

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SterlingLib.STIOrder stiOrder = new SterlingLib.STIOrder();
        private SterlingLib.STIQuote stiQuote = new SterlingLib.STIQuote(); 


        [StructLayout(LayoutKind.Sequential)]

        public class SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
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
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            stiOrder.Symbol = "IBM";
            stiOrder.Account = "YOUR ACCOUNT";
            stiOrder.Side = "B";
            stiOrder.Quantity = 100;
            stiOrder.Destination = "EDGA";
            stiOrder.Tif = "D";
            stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTIMkt;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = "ACCOUNT" + st.wYear + st.wMonth + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int ord = stiOrder.SubmitOrder();
            if (ord != 0)
            {
                MessageBox.Show("Order Error: " + ord.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        stiQuote.RegisterQuote("IBM", "*");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
