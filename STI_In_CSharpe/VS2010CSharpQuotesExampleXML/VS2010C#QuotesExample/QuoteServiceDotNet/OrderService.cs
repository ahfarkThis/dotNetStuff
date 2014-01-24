using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace QuoteServiceDotNet
{
    public class OrderService
    {
        public static string MarketOrder(string code, string account, string exch, string side, int quantity) //, bool isMarket)
        {
            SterlingLib.STIOrder stiOrder = new SterlingLib.STIOrder();
            stiOrder.Symbol = code;
            stiOrder.Account = account;
            stiOrder.Side = side;//B or S
            stiOrder.Quantity = quantity;
            stiOrder.Destination = exch;
            stiOrder.Tif = "D";
            //if(isMarket)
                stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTIMkt;
            //else
                //stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTILmt;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = account + st.wYear + st.wMonth + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int ord = stiOrder.SubmitOrder();
            if (ord != 0)
            {
                throw new ApplicationException("error code from PlaceOrder was non zero" + ord);
            }
            return stiOrder.ClOrderID;  
        }

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

        public static string LimitOrder(string code, string account, string exch, string side, int quantity, float lmtPrice) //, bool isMarket)
        {
            SterlingLib.STIOrder stiOrder = new SterlingLib.STIOrder();
            stiOrder.Symbol = code;
            stiOrder.Account = account;
            stiOrder.Side = side;//B or S
            stiOrder.Quantity = quantity;
            stiOrder.Destination = exch;
            stiOrder.Tif = "D";
            stiOrder.LmtPrice = lmtPrice;
         
            stiOrder.PriceType = SterlingLib.STIPriceTypes.ptSTILmt;

            SYSTEMTIME st = new SYSTEMTIME();
            LibWrap.GetSystemTime(st);
            stiOrder.ClOrderID = account + st.wYear + st.wMonth + st.wDay + st.wHour + st.wMinute + st.wSecond + st.wMilliseconds;
            int ord = stiOrder.SubmitOrder();
            if (ord != 0)
            {
                throw new ApplicationException("error code from PlaceOrder was non zero" + ord);
            }
            return stiOrder.ClOrderID;
        }

        public static void CancelOrder(string ClOrderID, string account)
        {
            SterlingLib.STIOrderMaint stiOrderMaint = new SterlingLib.STIOrderMaint();
            string ClOrderIDCancel = ClOrderID + "CX";
            stiOrderMaint.CancelOrder(account, 0, ClOrderID, ClOrderIDCancel);
        }

        public static void CancelAllOrders()
        {
            SterlingLib.STIOrderMaint stiOrderMaint = new SterlingLib.STIOrderMaint();
            SterlingLib.structSTICancelAll stiCancelAll = new SterlingLib.structSTICancelAll();
            stiCancelAll.bExtendingOnly = 0;
            stiCancelAll.bstrInstrument = "E";
            stiOrderMaint.CancelAllOrders(ref stiCancelAll);
        }

    }
}
