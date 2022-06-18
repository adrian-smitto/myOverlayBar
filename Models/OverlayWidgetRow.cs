using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOverlay.Models
{
    public class OverlayWidgetRow
    {
        public int Id { get; set; }
        public List<OverlayWidgetItem> Items { get; set; } = new List<OverlayWidgetItem>();
    }
}
