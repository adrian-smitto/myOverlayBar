using MyOverlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.OverlayWidgets
{
    public interface IOverlayWidget
    {
        Control GetControl(OverlayWidgetItem item);
    }
}
