using MyOverlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay
{
    public partial class Form1 : Form
    {
        #region Props

        public Config _config = JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json"));
        public Timer _mainTimer;
        public List<OverlayWidgetItem> myWidgets = new List<OverlayWidgetItem>();

        #endregion Props

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowTransparency = true;
            this.BackColor = Color.White;
            //this.TransparencyKey = Color.Black;
            this.ControlBox = false;
            this.Text = null;
            this.TopMost = true;
            
            this.Top = _config.Y;

            this.FormBorderStyle = FormBorderStyle.None;
            this.MinimumSize = new Size(1, 1);
            this.Size = new Size(1, 1);
            this.Text = _config.Name;

            RenderLayout();
            SetRefresh();

            this.Left = Screen.AllScreens[_config.Screen - 1].WorkingArea.X + _config.X-this.Width;
        }

        private void SetRefresh()
        {
            _mainTimer = new Timer() { Interval = 500, Enabled = true };
            _mainTimer.Tick += mainTimer_Tick;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            foreach (var widget in myWidgets)
            {
                var ctl = this.Controls.Cast<Control>().ToList().FirstOrDefault(r => r.Tag == widget.Id);
                if (ctl != null)
                {
                    var newctl = widget.GetRefreshedControl();
                    OverlayWidgetPictureBoxItem.Update(ctl, newctl);
                }
            }
        }

        private void RenderLayout()
        {
            var top = 0;
            foreach (var row in LayoutHelper.Layout.Rows)
            {
                AddLayoutRow(top, row);
                top += row.Items.Max(x => x.Height);
            }
            this.Size = new Size(this.Width, top);
        }

        private void AddLayoutRow(int top, OverlayWidgetRow row)
        {
            var left = 0;
            foreach (var item in row.Items)
            {
                AddLayoutItem(top,left, item);
                left += item.Control.Width;
                //set max width while going
                if(left > this.Width)
                {
                    this.Size = new Size(left, this.Height);
                }
            }
        }

        private void AddLayoutItem(int top, int left, OverlayWidgetItem item)
        {
            var ctl = item.Control;
            ctl.Top = top;
            ctl.Left = left;
            this.Controls.Add(ctl);
            this.myWidgets.Add(item);
        }


    }
}
