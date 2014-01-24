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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace TimeAndSalesWithQuoteOrderExample
{
    public partial class Form1 : Form
    {
        
        private SterlingLib.STIQuote stiQuote = new SterlingLib.STIQuote();  //declare STIQuote object
        private SterlingLib.STIApp stiApp = new SterlingLib.STIApp();        //declare STIApp object

        private SterlingLib.STIOrder stiOrder = new SterlingLib.STIOrder();  //declare STIOrder object
        
        private bool bModeXML = true;                                     // declare XML Enabler 

        private double currentBid;
        private double currentAsk;

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
            stiApp.SetModeXML(bModeXML);                  //Turn ON XML 

            symbolText.Text = "SPY";
            accountText.Text = "Type in your account...";
            qtyText.Text = "100";
            destText.Text = "NYSE";

            //Subscribe to QuoteUpdates 
            stiQuote.OnSTIQuoteUpdateXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteUpdateXMLEventHandler(OnSTIQuoteUpdateXML);
            stiQuote.OnSTIQuoteSnapXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteSnapXMLEventHandler(OnSTIQuoteSnapXML);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tsListBox.Items.Clear();
            stiQuote.DeRegisterAllQuotes();
            stiQuote.RegisterQuote(symbolText.Text.ToUpper(), "");
        }

        //XML Quote_Snap Event listener
        private void OnSTIQuoteSnapXML(ref string strQuote)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteSnap));
            SterlingLib.structSTIQuoteSnap structQuote = (SterlingLib.structSTIQuoteSnap)xs.Deserialize(new StringReader(strQuote));

            UpdateLastLabel(structQuote.fLastPrice);
            UpdateBidLabel(structQuote.fBidPrice);
            UpdateAskLabel(structQuote.fAskPrice);
            UpdateBidSizeLabel(structQuote.nBidSize);
            UpdateAskSizeLabel(structQuote.nAskSize);     
            
        }
        //XML Quote Event Listener
        private void OnSTIQuoteUpdateXML(ref string strQuote)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteUpdate));
            SterlingLib.structSTIQuoteUpdate structQuote = (SterlingLib.structSTIQuoteUpdate)xs.Deserialize(new StringReader(strQuote));

            string row = structQuote.bstrUpdateTime + "        " + structQuote.fLastPrice.ToString("#####.##") + "        " + structQuote.nLastSize.ToString("#####") + "        " + structQuote.bstrLastExch;

            if (structQuote.bLastPrice == 1)
            {
                UpdateLastLabel(structQuote.fLastPrice);
                AddListBoxItem(row);
            }
                if (structQuote.bBidPrice == 1)
            {
                UpdateBidLabel(structQuote.fBidPrice);
                UpdateBidSizeLabel(structQuote.nBidSize);

                currentBid = structQuote.fBidPrice;
            }
            if (structQuote.bAskPrice == 1)
            {
                UpdateAskLabel(structQuote.fAskPrice);
                UpdateAskSizeLabel(structQuote.nAskSize);
                currentAsk = structQuote.fAskPrice;
            }
            
        }

        private delegate void UpdateQuoteTextDelegate(object item);

        private void UpdateLastLabel(object item)
        {
            if (InvokeRequired)
            {
                this.quoteLabel.Invoke(new UpdateQuoteTextDelegate(UpdateLastLabel), item);
            }
            else
                quoteLabel.Text = item.ToString();
        }
        private void UpdateBidLabel(object item)
        {
            if (InvokeRequired)
            {
                this.bidLabel.Invoke(new UpdateQuoteTextDelegate(UpdateBidLabel), item);

            }
            else
                bidLabel.Text = item.ToString();
        }
        private void UpdateAskLabel(object item)
        {
            if (InvokeRequired)
            {
                this.askLabel.Invoke(new UpdateQuoteTextDelegate(UpdateAskLabel), item);

            }
            else
                askLabel.Text = item.ToString();
        }
        private void UpdateBidSizeLabel(object item)
        {
            if (InvokeRequired)
            {
                this.bSizeLabel.Invoke(new UpdateQuoteTextDelegate(UpdateBidSizeLabel), item);

            }
            else
                bSizeLabel.Text = item.ToString();
        }
        private void UpdateAskSizeLabel(object item)
        {
            if (InvokeRequired)
            {
                this.aSizeLabel.Invoke(new UpdateQuoteTextDelegate(UpdateAskSizeLabel), item);

            }
            else
                aSizeLabel.Text = item.ToString();
        }

        public delegate void AddListBoxItemDelegate(Object structQuote);

        private void AddListBoxItem(Object structQuote)
        {
            if (InvokeRequired)
            {
                this.tsListBox.Invoke(new AddListBoxItemDelegate(AddListBoxItem), structQuote);
            }
            else
            this.tsListBox.Items.Add(structQuote);
        }


        private void buyButton_Click(object sender, EventArgs e)
        {
            stiOrder.Symbol = symbolText.Text.ToUpper();
            stiOrder.Account = accountText.Text.ToUpper();
            stiOrder.Side = "B";
            stiOrder.Quantity = Convert.ToInt32(qtyText.Text);
            stiOrder.Destination = destText.Text.ToUpper();
            stiOrder.Tif = "D";
            stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTILmt;
            stiOrder.LmtPrice = currentBid;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = accountText.Text + st.wYear + st.wMonth + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int ord = stiOrder.SubmitOrder();
            if (ord != 0)
            {
                MessageBox.Show("Order Error: " + ord.ToString());
            }
            lbMsgs.Items.Add(stiOrder.ClOrderID);
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            stiOrder.Symbol = symbolText.Text.ToUpper();
            stiOrder.Account = accountText.Text.ToUpper();
            stiOrder.Side = "S";
            stiOrder.Quantity = Convert.ToInt32(qtyText.Text);
            stiOrder.Destination = destText.Text.ToUpper();
            stiOrder.Tif = "D";
            stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTILmt;
            stiOrder.LmtPrice = currentAsk;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = accountText.Text + st.wYear + st.wMonth + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int ord = stiOrder.SubmitOrder();
            if (ord != 0)
            {
                MessageBox.Show("Order Error: " + ord.ToString());
            }
            lbMsgs.Items.Add(stiOrder.ClOrderID);

        }

     
        
    }
}
