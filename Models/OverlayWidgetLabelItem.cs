using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.Models
{
    public static class OverlayWidgetLabelItem
    {
        public static Label Build(OverlayWidgetItem item)
        {
            var rtn = new Label();
            rtn.Width = item.Width;
            rtn.Height = item.Height;
            rtn.Text = item.Value;
            return rtn;
        }
    }
}
