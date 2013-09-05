namespace Game
{

    public class CoupleDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static readonly CoupleDouble zero = new CoupleDouble(0, 0);
        public static readonly CoupleDouble ones = new CoupleDouble(1, 1);

        protected bool Equals(CoupleDouble other)
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
            
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoupleDouble) obj);
        }

        public static CoupleDouble operator +(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X + second.X, first.Y + second.Y);
        }

        public static CoupleDouble operator -(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X - second.X, first.Y - second.Y);
        }

        public static CoupleDouble operator *(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X * second.X, first.Y * second.Y);
        }


        public static CoupleDouble operator /(CoupleDouble first, CoupleDouble second)
        {
            return new CoupleDouble(first.X - second.X, first.Y - second.Y);
        }

        public static CoupleDouble operator ++(CoupleDouble first)
        {
            return first + ones;
        }
    }
}
