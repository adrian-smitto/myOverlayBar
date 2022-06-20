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
    public class OverlayWidgetPictureBoxItem
    {
        private object _handler { get; set; }
        public object Handler
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
        public PictureBox Build(OverlayWidgetItem item)
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
        }

        internal static void UpdateControl(Control oldControl, Control newControl)
        {
            oldControl.BackColor = newControl.BackColor;
            oldControl.Refresh();
        }
    }
}
