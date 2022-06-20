using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOverlay.OverlayWidgets.Models
{
    public class BinanceTickerResponse
    {
        public string symbol { get; set; }
        public string price { get; set; }
    }

    public class BinanceTickerConfig
    {
        public string symbol { get; set; }
    }
}
