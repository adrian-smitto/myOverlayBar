using MyOverlay.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyOverlay
{
    public static class LayoutHelper
    {
        private static OverlayLayout _layout { get; set; }
        public static OverlayLayout Layout
        {
            get
            {
                if (_layout == null)
                {
                    LoadLayout();
                }

                return _layout;
            }

        }


        /// <summary>
        /// can be improved. quick workaround to load and generate correct layout
        /// </summary>
        private static void LoadLayout()
        {
            var json = File.ReadAllText("layout.json");
            _layout = JsonSerializer.Deserialize<OverlayLayout>(json);
        }

    }
}
