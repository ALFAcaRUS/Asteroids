using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entitys;

namespace Game.Weapons
{
    class Laser:IWeapon
    {
        public int Charge { get; set; }
        public int Distance { get; set; }

        public List<AEntity> Shot(CoupleInt pos)
        {
            throw new NotImplementedException();
        }
    }
}
