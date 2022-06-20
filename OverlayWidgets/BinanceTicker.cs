using MyOverlay.Models;
using MyOverlay.OverlayWidgets.Models;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Text.Json;
using System;
using System.Drawing;

namespace MyOverlay.OverlayWidgets
{
    public class BinanceTicker : IOverlayWidget
    {
        public static string _baseURL = "https://api.binance.com/api/v3/ticker/price?symbol=";
        public double Price { get; set; }
        public string Symbol { get; set; }
        public Control GetControl(OverlayWidgetItem item)
        {
            var config = System.Text.Json.JsonSerializer.Deserialize<BinanceTickerConfig>(item.Data.ToString());
            Symbol = config.symbol;

            var rsp = GetResponse();
            var newPrice = Math.Round(Convert.ToDouble(rsp.price));

            var rtn = new Label() {Font = new Font("Arial", 8, FontStyle.Bold), Width = item.Width, Height = item.Height, Text = "$" + newPrice };
            rtn.TextAlign = ContentAlignment.MiddleCenter;

            if (newPrice > Price)
            {
                rtn.BackColor = Color.Green;
                rtn.ForeColor = Color.White;
            }
            else
            {
                rtn.BackColor = Color.Red;
                rtn.ForeColor = Color.White;
            }
            Price = newPrice;
            return rtn;
        }

        private BinanceTickerResponse GetResponse()
        {
            string data = null;
            var request = WebRequest.Create(_baseURL+Symbol);
            request.Method = "GET";

            using (var webResponse = request.GetResponse()) {
                using (var webStream = webResponse.GetResponseStream()) {

                    using (var reader = new StreamReader(webStream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }

            return JsonSerializer.Deserialize<BinanceTickerResponse>(data);
        }
    }
}
