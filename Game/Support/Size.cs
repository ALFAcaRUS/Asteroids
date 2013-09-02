using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Support
{
    public class Size
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Size(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
