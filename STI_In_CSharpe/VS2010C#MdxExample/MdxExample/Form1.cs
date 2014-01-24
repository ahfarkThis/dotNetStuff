//  Solely as an accommodation to Subscriber, Sterling has agreed to provide sample
//  source code (“Code”) to demonstrate how Subscriber might be able to develop its 
//  own software code to facilitate Subscriber’s interaction with the Sterling front-end 
//  modules via Sterling’s Application Programming Interface (API). Sterling is 
//  providing the Code “as is”, and Sterling has no obligation to provide any updates, 
//  revisions, modifications or enhancements to the Code. Sterling is not writing or 
//  assisting in writing Subscriber’s code, and consequently Sterling has no 
//  responsibility or liability for Subscriber’s use or modification of the Code. 
//  STERLING EXPRESSLY DISCLAIMS ALL REPRESENTATIONS AND 
//  WARRANTIES, EXPRESS OR IMPLIED, WITH RESPECT TO THE CODE, 
//  INCLUDING THE WARRANTIES OF MERCHANTABILITY AND OF 
//  FITNESS FOR A PARTICULAR PURPOSE. UNDER NO 
//  CIRCUMSTANCES INCLUDING NEGLIGENCE SHALL STERLING BE 
//  LIABLE FOR ANY DAMAGES, INCIDENTAL, SPECIAL, 
//  CONSEQUENTIAL OR OTHERWISE (INCLUDING WITHOUT LIMITATION 
//  DAMAGES FOR LOSS OF PROFITS, BUSINESS INTERRUPTION, LOSS 
//  OF INFORMATION OR OTHER PECUNIARY LOSS) THAT MAY RESULT 
//  FROM THE USE OF OR INABILITY TO USE THE CODE, EVEN IF 
//  STERLING HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH 
//  DAMAGES.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace MdxExample
{
    public partial class Form1 : Form
    {
        private SterlingLib.STIQuote stiQuote = new SterlingLib.STIQuote();
        private SterlingLib.STIApp stiApp = new SterlingLib.STIApp();
        private SterlingLib.structSTIMdxRegEx pmdx = new SterlingLib.structSTIMdxRegEx();      //initilize pmdx Object

        private List<string> listMsg = new List<string>();
        private bool bModeXML = true;


        public Form1()
        {
            InitializeComponent();
            stiApp.SetModeXML(bModeXML);

            pmdx.bNewOnly = 0;
            pmdx.bReg = 1;
            pmdx.bstrExchanges = "";             //Register for all exchanges
            
            //pmdx.bstrMsgTypes = "1";              //Reg Imb
            pmdx.bstrMsgTypes = "2";            //Info Imb

            stiQuote.OnSTIQuoteUpdateXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteUpdateXMLEventHandler(OnSTIQuoteUpdateXML);
            stiQuote.OnSTIQuoteSnapXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteSnapXMLEventHandler(OnSTIQuoteSnapXML);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            stiQuote.DeRegisterAllQuotes();
            listBox1.Items.Clear();

            pmdx.bAllSyms = 1;                     // you can register for all symbols
            //stiQuote.RegisterQuote("BAC","");   //or you can register for specific symbols

            stiQuote.RegisterMdxEx(pmdx);
        }  
            
    

        private void OnSTIQuoteSnapXML(ref string strQuote)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteSnap));
            SterlingLib.structSTIQuoteSnap structQuote = (SterlingLib.structSTIQuoteSnap)xs.Deserialize(new StringReader(strQuote));
            AddListBoxItem("Mdx Quote Snap Triggered");
        }
        private void OnSTIQuoteUpdateXML(ref string strQuote)
        {
           XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteUpdate));
           SterlingLib.structSTIQuoteUpdate structQuote = (SterlingLib.structSTIQuoteUpdate)xs.Deserialize(new StringReader(strQuote));

           
               AddListBoxItem(structQuote.bstrSymbol);
               AddListBoxItem(structQuote.nImbalance);
               AddListBoxItem(structQuote.nMktImbalance);
               AddListBoxItem(structQuote.nMdxMsgType);
          

        }

     
        public delegate void AddListBoxItemDelegate(object structQuote);


        private void AddListBoxItem(object structQuote)
        {
            if (InvokeRequired)
            {
                this.listBox1.Invoke(new AddListBoxItemDelegate(AddListBoxItem), structQuote);
            }
            else
                listBox1.Items.Add(structQuote);
        }



    }
}
