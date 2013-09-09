using System.Drawing;
using Asteroids.Source;
using Game;

namespace Asteroids.GraphicConstructors
{
    internal abstract class AGraphicConstructor
    {
        protected CoupleDouble scale = CoupleDouble.ones;
        protected CoupleDouble offset = CoupleDouble.zero;
        protected SourcesList _sourcesList = new SourcesList();

        public void Init(int width, int height)
        {
            scale = new CoupleDouble(width / 200.0, height / 200.0);
            offset = scale * new CoupleDouble(100, 100);
        }

        public abstract void GetImage(ViewObject obj, Graphics grap);
    }
}
