using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.Models
{
    public static class OverlayWidgetPictureBoxItem
    {
        public static PictureBox Build(OverlayWidgetItem item)
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
    }
}
