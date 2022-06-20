using MyOverlay.OverlayWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.Models
{
    public static class OverlayWidgetPictureBoxItem
    {
        private static object _handler { get; set; }
        public static object Handler
        {
            get
            {
                if (_handler == null)
                {
                    var t = Assembly.GetExecutingAssembly().GetType("MyOverlay.OverlayWidgets.Pinger");
                    _handler = Activator.CreateInstance(t);
                }
                return _handler;
            }

        }
        public static PictureBox Build(OverlayWidgetItem item)
        {
            if (string.IsNullOrEmpty(item.Class))
            {
                var rtn = new PictureBox();
                rtn.Width = item.Width;
                rtn.Height = item.Height;
                rtn.ImageLocation = item.Value;
                rtn.SizeMode = PictureBoxSizeMode.StretchImage;
                rtn.Load(rtn.ImageLocation);
                rtn.Show();
                return rtn;
            }
            else
            {
                
                return (PictureBox) ((IOverlayWidget)Handler).GetControl(item);
            }
            return new PictureBox();
        }

        internal static void Update(Control ctl, Control newctl)
        {
            ctl.BackColor = newctl.BackColor;
            ctl.Refresh();
        }
    }
}
