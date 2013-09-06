using System;

namespace Game
{
    class Degree
    {
        private double _value = 0;

        public double Angle
        {
            get
            {
                return _value;
            }

            set
            {
                while (value > 360)
                {
                    value -= 360;
                }
                while (value < 0)
                {
                    value += 360;
                }

                _value = value;
            }
        }

        public Degree()
        {
            
        }

        public Degree(double value)
        {
            Angle = value;
        }

        public double ToRadian()
        {
            return Angle*Math.PI/180;
        }

        public void SetWhithRadian(double value)
        {
            Angle = value*180/Math.PI;
        }

        public CoupleDouble GetProjections()
        {
            return new CoupleDouble(Math.Cos(ToRadian()), Math.Sin(ToRadian()));
        }

        public void SetProjections(CoupleDouble value)
        {
            SetWhithRadian(Math.Atan(value.Y/value.X));
        }

        public static Degree operator +(Degree first, Degree second)
        {
            return new Degree(first.Angle + second.Angle);
        }

        public static Degree operator +(Degree first, Double second)
        {
            return new Degree(first.Angle + second);
        }

        public static Degree operator -(Degree first, Degree second)
        {
            return new Degree(first.Angle - second.Angle);
        }

        public static Degree operator -(Degree first, Double second)
        {
            return new Degree(first.Angle - second);
        }
    }
}
