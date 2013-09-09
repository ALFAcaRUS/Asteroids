using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Shapes;
using Game;

namespace Asteroids.GraphicConstructors
{
    class PoligonGraphicConstructor:AGraphicConstructor
    {
        public override void GetImage(ViewObject obj, Graphics grap)
        {
            CoupleDouble point = obj.Pos * scale + offset;
            CoupleDouble size = obj.Size * scale;

            switch (obj.Name)
            {
                case "Ship":
                    DrawShip(point, size, obj.RotateAngle, grap);
                    break;
                case "Asteroid":
                    DrawAsteroid(point, size, obj.RotateAngle, grap);
                    break;
                case "Ufo":
                    DrawUfo(point, size, obj.RotateAngle, grap);
                    break;
                case "Exsplosion":
                    DrawExplosion(point, size, obj.RotateAngle, grap);
                    break;
                case "LaserBulet":
                    DrawLaserBullet(point, size, obj.RotateAngle, grap);
                    break;
                case "GunBullet":
                    DrawGunBullet(point, size, obj.RotateAngle, grap);
                    break;
            }

        }

        private void DrawShip(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            Point[] points = new Point[4];
            Brush shipBrush;

            angle += 90;

            points[0] = (pos + size * angle.GetProjections()).GetPoint();
            points[1] = (pos + (size/3)*(angle - 90).GetProjections()).GetPoint();
            points[2] = (pos + size * (angle + 180).GetProjections()).GetPoint();
            points[3] = (pos + (size/3)*(angle + 90).GetProjections()).GetPoint();

            shipBrush = Brushes.DarkGray;

            e.FillPolygon(shipBrush, points);

            points[0] = (pos + size * (angle - 90).GetProjections()).GetPoint();
            points[1] = (pos + size * (angle + 60).GetProjections()).GetPoint();
            points[2] = (pos + (size / 2) * (angle + 90).GetProjections()).GetPoint();
            points[3] = (pos + size * (angle + 120).GetProjections()).GetPoint();

            shipBrush = Brushes.LightBlue;

            e.FillPolygon(shipBrush, points);
            e.DrawPolygon(new Pen(Brushes.Black), points);

            points[0] = (pos + size * 0.3 * (angle - 90).GetProjections()).GetPoint();
            points[1] = (pos + size * 0.3 * (angle + 60).GetProjections()).GetPoint();
            points[2] = (pos + (size / 2) * 0.3 * (angle + 90).GetProjections()).GetPoint();
            points[3] = (pos + size * 0.3 * (angle + 120).GetProjections()).GetPoint();

            shipBrush = Brushes.Black;

            e.FillPolygon(shipBrush, points);
        }

        private void DrawUfo(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            Point[] points = new Point[36];

            for (int i = 0; i < 36; i++)
            {
                points[i] = (pos + size * (angle + 10*i).GetProjections()).GetPoint();
            }

            Brush shipBrush = Brushes.DarkGray;

            e.FillPolygon(shipBrush, points);
            e.DrawPolygon(new Pen(Brushes.Black), points);


            for (int i = 0; i < 36; i++)
            {
                points[i] = (pos + size/5 * (angle + 10 * i).GetProjections()).GetPoint();
            }

            shipBrush = Brushes.Black;

            e.FillPolygon(shipBrush, points);
        }

        private void DrawAsteroid(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < 36; i++)
            {
                if ((((i >= 1) && (i <= 9)) || ((i > 13) && (i < 18)) || ((i > 20) && (i < 24)) || ((i >= 29) && (i <= 33))))
                {
                    points.Add((pos + (size)*(angle + 10*i).GetProjections()).GetPoint());
                }
            }

            Brush shipBrush = Brushes.SlateGray;

            e.FillPolygon(shipBrush, points.ToArray());
            e.DrawPolygon(new Pen(Brushes.Black), points.ToArray());
        }

        private void DrawGunBullet(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            Point[] points = new Point[4];
            Brush shipBrush;

            angle += 90;

            points[0] = (pos + size * (angle - 90).GetProjections()).GetPoint();
            points[1] = (pos + size * (angle + 60).GetProjections()).GetPoint();
            points[2] = (pos + (size / 2) * (angle + 90).GetProjections()).GetPoint();
            points[3] = (pos + size * (angle + 120).GetProjections()).GetPoint();

            shipBrush = Brushes.Gold;

            e.FillPolygon(shipBrush, points);
        }

        private void DrawLaserBullet(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            e.FillPolygon(Brushes.Red,RotatingRectangle.GetPoligon(pos,size,angle));
        }

        private void DrawExplosion(CoupleDouble pos, CoupleDouble size, Degree angle, Graphics e)
        {
            Random ran = new Random();

            List<Point> points = new List<Point>();

            for (int i = 0; i < 6; i++)
            {
                if ((((i >= 1) && (i <= 9)) || ((i > 13) && (i < 18)) || ((i > 20) && (i < 24)) || ((i >= 29) && (i <= 33))))
                {
                    points.Add((pos + (size) * (angle + 60 * i + 30 *ran.NextDouble()).GetProjections()).GetPoint());
                }
            }

            Brush shipBrush = Brushes.Yellow;
            Pen explosionPen = new Pen(Brushes.Red);

            explosionPen.Width = 5;

            e.FillPolygon(shipBrush, points.ToArray());
            e.DrawPolygon(explosionPen, points.ToArray());
        }
    }
}
