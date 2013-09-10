namespace Game
{
    public class ViewObject
    {
        public string Name { get; set; }
        public CoupleDouble Pos { get; set; }
        public CoupleDouble Size { get; set; }
        public Degree RotateAngle { get; set; }

        public ViewObject(string name, CoupleDouble pos, CoupleDouble size,Degree angle)
        {
            Name = name;
            Pos = pos;
            Size = size;
            RotateAngle = angle;
        }
    }
}
