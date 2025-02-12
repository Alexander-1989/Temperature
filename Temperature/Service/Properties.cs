using System;
using System.Drawing;

namespace Temperature.Service
{
    [Serializable]
    public class Properties
    {
        public Point Location { get; set; } = new Point(0, 0);
        public bool DarkTheme { get; set; } = false;
        public string ComPortName { get; set; } = string.Empty;
        public bool AutoConnect { get; set; } = false;
        public bool StartMinimize { get; set; } = false;
        public bool MinimizeOnClose { get; set; } = false;
    }
}
