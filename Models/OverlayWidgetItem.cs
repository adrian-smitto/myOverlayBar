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
        public object Data { get; set; } //json config


        private Control _control { get; set; }
        private object _builder { get; set; }

        public object Builder
        {
            get
            {
                if (_builder == null)
                {
                    if (Type == (int)ItemType.Icon)
                    {
                        _builder = new OverlayWidgetPictureBoxItem();
                    }
                    if (Type == (int)ItemType.Text)
                    {
                        _builder = new OverlayWidgetLabelItem();
                    }
                }
                return _builder;
            }
        }

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

        public void UpdateControl(Control dest, Control source)
        {
            if (Type == (int)ItemType.Icon)
            {
                OverlayWidgetPictureBoxItem.UpdateControl(dest, source);
            }
            if (Type == (int)ItemType.Text)
            {
               OverlayWidgetLabelItem.UpdateControl(dest, source);
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
                _control = ((OverlayWidgetPictureBoxItem)Builder).Build(this);
            }
            if (Type == (int)ItemType.Text)
            {
                _control = ((OverlayWidgetLabelItem)Builder).Build(this);
            }

            _control.Tag = Id;
        }
    }
}
