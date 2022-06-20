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
    public class OverlayWidgetLabelItem
    {
        private object _handler { get; set; }
        public object Handler
        {
            get
            {
                if (_handler == null)
                {
                    var t = Assembly.GetExecutingAssembly().GetType("MyOverlay.OverlayWidgets.BinanceTicker");
                    _handler = Activator.CreateInstance(t);
                }
                return _handler;
            }
        }
        public Label Build(OverlayWidgetItem item)
        {
            if (string.IsNullOrEmpty(item.Class))
            {
                var rtn = new Label();
                rtn.Width = item.Width;
                rtn.Height = item.Height;
                rtn.Text = item.Value;
                return rtn;
            }
            else
            {
                return (Label)((IOverlayWidget)Handler).GetControl(item);
            }
        }

        internal static void UpdateControl(Control oldControl, Control newControl)
        {
            oldControl.BackColor = newControl.BackColor;
            oldControl.Text = newControl.Text;
            oldControl.ForeColor = newControl.ForeColor;
            oldControl.Update();
            oldControl.Refresh();
        }
    }
}
