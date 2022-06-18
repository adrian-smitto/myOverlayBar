using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay.Models
{
    public class OverlayWidgetItem
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Class { get; set; }
        public string Value { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Control _control { get; set; }
        public Control Control
        {
            get
            {
                if (_control == null)
                {
                    Build();
                }
                return _control;
            }
        }

        public void Build()
        {
            if(Type == (int)ItemType.Icon)
            {
                _control = OverlayWidgetPictureBoxItem.Build(this);
            }
            if (Type == (int)ItemType.Text)
            {
                _control = OverlayWidgetLabelItem.Build(this);
            }


        }
    }
}
