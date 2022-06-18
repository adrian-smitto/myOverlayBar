using MyOverlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOverlay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var pixelsFromX = 1980;

            this.AllowTransparency = true;
            this.BackColor = Color.White;
            //this.TransparencyKey = Color.Black;
            this.ControlBox = false;
            this.Text = null;
            this.TopMost = true;
            this.Left = Screen.AllScreens[0].WorkingArea.X + pixelsFromX - this.Width;
            this.Top = 0;

            this.FormBorderStyle = FormBorderStyle.None;
            this.MinimumSize = new Size(1, 1);
            this.Size = new Size(1, 1);

            RenderLayout();

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
        }


    }
}
