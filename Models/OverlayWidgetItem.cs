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
        public string Id { get; set; }

        private Control _control { get; set; }

        public Control GetRefreshedControl()
        {
            this.Refresh();
            return _control;
        }

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
            Id = Guid.NewGuid().ToString();

            Refresh();

        }

        private void Refresh()
        {
            if (Type == (int)ItemType.Icon)
            {
                _control = OverlayWidgetPictureBoxItem.Build(this);
            }
            if (Type == (int)ItemType.Text)
            {
                _control = OverlayWidgetLabelItem.Build(this);
            }

            _control.Tag = Id;
        }
    }
}
