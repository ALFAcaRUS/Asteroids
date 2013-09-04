namespace Game
{

    public class CoupleInt
    {
        protected bool Equals(CoupleInt other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public CoupleInt(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public CoupleInt()
        {
            
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoupleInt) obj);
        }
    }
}
