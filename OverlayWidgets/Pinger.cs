using MyOverlay.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.OverlayWidgets
{
    public class Pinger : IOverlayWidget
    {
        public int Success { get; set; }
        public int Fail { get; set; }

        public Control GetControl(OverlayWidgetItem item)
        {
            var pb = new PictureBox() { Width = 24, Height = 24 };
            Color color;
            if (!DoPing())
            {
                Fail++;
                color = Color.Red;
            }
            else
            {
                Success++;
                color = Color.Green;
            }

            Bitmap b = new Bitmap(24, 24);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0,pb.Width, pb.Height)); // i used this code to make the background color white 
            if (Fail > 0)
            {
                g.DrawString(Fail.ToString(), new Font("Arial", 10), new SolidBrush(Color.White), new PointF(0, 0));
            }
            pb.Image = b;

            return pb;

        }

        public bool DoPing()
        {
            try
            {
                var rslt = new Ping().Send("www.google.com");
                return rslt.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
