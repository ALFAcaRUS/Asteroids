using System;
using System.Drawing;

namespace Game
{

    public class CoupleDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static readonly CoupleDouble zero = new CoupleDouble(0, 0);
        public static readonly CoupleDouble ones = new CoupleDouble(1, 1);

        public bool Equals(CoupleDouble other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public CoupleDouble(double x, double y) 
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public CoupleDouble() 
        {
            X = 0;
            Y = 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoupleDouble) obj);
        }

        public Point GetPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public double GetDistance(CoupleDouble point)
        {
            double outPut = Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));

            return outPut;
        }

        public static CoupleDouble operator +(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X + second.X, first.Y + second.Y);
        }

        public static CoupleDouble operator +(CoupleDouble first, double second)
        {
            return new CoupleDouble(first.X + second, first.Y + second);
        }

        public static CoupleDouble operator -(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X - second.X, first.Y - second.Y);
        }

        public static CoupleDouble operator -(CoupleDouble first, double second)
        {
            return new CoupleDouble(first.X - second, first.Y - second);
        }

        public static CoupleDouble operator *(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X * second.X, first.Y * second.Y);
        }

        public static CoupleDouble operator *(CoupleDouble first, double second)
        {
            return new CoupleDouble(first.X * second, first.Y * second);
        }


        public static CoupleDouble operator /(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X / second.X, first.Y / second.Y);
        }


        public static CoupleDouble operator /(CoupleDouble first, double second)
        {
            return new CoupleDouble(first.X / second, first.Y / second);
        }

        public static CoupleDouble operator ++(CoupleDouble first)
        {
            return first + ones;
        }

        public static CoupleDouble operator --(CoupleDouble first)
        {
            return first - ones;
        }

        public static CoupleDouble operator -(CoupleDouble first)
        {
            return first * new CoupleDouble(-1,-1);
        }
    }
}
