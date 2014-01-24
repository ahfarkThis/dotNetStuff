using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace QuoteServiceDotNet
{
    public class QuoteService
    {
        public SterlingLib.STIQuote stiQuote; // = new SterlingLib.STIQuote();
        public SterlingLib.STIApp stiApp; // = new SterlingLib.STIApp();

        public List<Instrument> quotes; // = new List<Instrument>();

        public static QuoteService instance; //= new QuoteService();      // took off static here

        public QuoteService()       // shouldn't have to call this from Matlab?  should be initilized immediately and running
        {
            stiQuote = new SterlingLib.STIQuote();
            stiApp = new SterlingLib.STIApp();
            stiApp.SetModeXML(true);
            stiQuote.OnSTIQuoteUpdateXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteUpdateXMLEventHandler(OnSTIQuoteUpdateXML);
            stiQuote.OnSTIQuoteSnapXML += new SterlingLib._ISTIQuoteEvents_OnSTIQuoteSnapXMLEventHandler(OnSTIQuoteSnapXML);
            //ThreadPool.QueueUserWorkItem(ChangeInstrumentPrice);       
        }

        public void OnSTIQuoteSnapXML(ref string strQuote)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteSnap));
            SterlingLib.structSTIQuoteSnap structQuote = (SterlingLib.structSTIQuoteSnap)xs.Deserialize(new StringReader(strQuote));
        }

        public void OnSTIQuoteUpdateXML(ref string strQuote)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SterlingLib.structSTIQuoteUpdate));
            SterlingLib.structSTIQuoteUpdate structQuote = (SterlingLib.structSTIQuoteUpdate)xs.Deserialize(new StringReader(strQuote));
        }

        public static void Register(string code)  // both adds to list & registers sym with STI
        {
            if (!instance.quotes.Any(c => c.Name == code))        //  took of _instance in 3 spots here
            {
                instance.quotes.Add(new Instrument { Name = code, Ask = 39.5d, Bid = 41.2d, Exch = "abcd" }); 
            }
            instance.stiQuote.RegisterQuote(code, "*");
        }

        //private static void ChangeInstrumentPrice(object state)
        //{
        //    while (true)
        //    {
        //        foreach(var inst in _instance._quotes)
        //            _instance._quotes[0].Bid -= 0.1d;
        //        Thread.Sleep(5000);
        //    }
        //}

        
        //public static Instrument GetInstrument(string code)
        //{
        //    var instrument = _instance._quotes.FirstOrDefault(i => i.Name == code);
        //    if (instrument == null)
        //        throw new NotSupportedException("no such instrument with code " + code);
        //    return instrument;
        //}

        
    }
}
