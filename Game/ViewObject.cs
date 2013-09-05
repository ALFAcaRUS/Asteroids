namespace Game
{
    public class ViewObject
    {
        public string Name { get; set; }
        public CoupleDouble Pos { get; set; }

        public ViewObject(string name, CoupleDouble pos)
        {
            Name = name;
            Pos = pos;
        }
    }
}
