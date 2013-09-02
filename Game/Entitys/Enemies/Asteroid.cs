using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entitys;
using Game.Support;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AsteroidsTest")]

namespace Game.Entitys.Enemies
{

    internal class Asteroid : AEntity
    {
        private int _parts = 2;

        public Asteroid(CoupleInt pos, CoupleInt size, CoupleInt speed)
            : base(pos, size, speed)
        {

        }

        public Asteroid(CoupleInt pos, CoupleInt size, CoupleInt speed, int parts)
            : base(pos, size, speed)
        {
            this._parts = parts;
        }

        internal override void ChengeState()
        {
            throw new NotImplementedException();
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
