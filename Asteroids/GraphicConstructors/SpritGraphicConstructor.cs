using System;
using System.Collections.Generic;
using System.Drawing;
using Asteroids.Shapes;
using Asteroids.Source;
using Game;

namespace Asteroids.GraphicConstructors
{
    class SpritGraphicConstructor : AGraphicConstructor
    {
        public override void GetImage(ViewObject obj, Graphics grap)
        {
            CoupleDouble point = obj.Pos * scale + offset;
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
