using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Source
{
    internal class SourcesList
    {

        public IDictionary<string, Image> Images = new Dictionary<string, Image>();

        public SourcesList()
        {
            Images.Add("Ship", Image.FromFile(@"Source/Sprits/Sprit_Ship 2.png"));
            Images.Add("Asteroid", Image.FromFile(@"Source/Sprits/Sprit_Asteroid.png"));
            Images.Add("Ufo", Image.FromFile(@"Source/Sprits/Sprit_Ufu.png"));
            Images.Add("Exsplosion", Image.FromFile(@"Source/Sprits/Explosion.png"));
            Images.Add("LaserBulet", Image.FromFile(@"Source/Sprits/LaserBullet.png"));
            Images.Add("GunBullet", Image.FromFile(@"Source/Sprits/GunBullet.png"));

        }

    }
}
