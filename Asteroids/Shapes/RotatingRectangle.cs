using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace Asteroids.Shapes
{
    internal class RotatingRectangle
    {

        public static Point[] GetPoints(CoupleDouble centr, CoupleDouble size, Degree angle)
        {
            Point[] output = new Point[3];

            output[0] = (centr + size*(angle - 45).GetProjections()).GetPoint();
            output[2] = (centr + size*(angle + 45).GetProjections()).GetPoint();
            //output[2] = (Centr + Size * (Angle + 135).GetProjections()).GetPoint();
            output[1] = (centr + size*(angle - 135).GetProjections()).GetPoint();

            return output;
        }
    }
}
