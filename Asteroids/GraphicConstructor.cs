using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Shapes;
using Asteroids.Source;
using Game;

namespace Asteroids
{
    class GraphicConstructor
    {

        CoupleDouble scale = CoupleDouble.ones;
        CoupleDouble offset = CoupleDouble.zero;
        SourcesList _sourcesList = new SourcesList();

        public void Init(int width, int height)
        {
            scale = new CoupleDouble(width / 200.0, height / 200.0);
            offset = scale * new CoupleDouble(100, 100);
        }

        public void GetImage(ViewObject obj, Graphics grap)
        {
            CoupleDouble point = obj.Pos * scale * 0.9 + offset;
            CoupleDouble size = obj.Size * scale;

            Bitmap ship = new Bitmap(32, 32);
            Graphics shipGraphics = Graphics.FromImage(ship);

            Rectangle shipRectangle = new Rectangle(0, 0, 32, 32);

            string name = obj.Name;
            Image image = null;

            _sourcesList.Images.TryGetValue(name,out image);

            Brush shipBrush = null != image? new TextureBrush(image) : Brushes.Black;

            shipGraphics.FillRectangle(shipBrush, shipRectangle);

            grap.DrawImage(ship, RotatingRectangle.GetPoints(point, size, obj.RotateAngle));
        }

    }
}
