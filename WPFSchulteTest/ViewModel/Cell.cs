using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp2
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    internal class Cell
    {
        public SolidColorBrush BorderColor { get; set; }
        public Brush BackColor { get; set; }
        public int? Number { get; set; }
        public bool CanPress { get; set; }
        public bool Pressed { get; set; }
        public bool Eye { get; set; }
    }
}
