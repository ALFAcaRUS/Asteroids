﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Support;
using Game.Entitys.bullets;

namespace Game.Entitys.Enemies
{
    internal class Ufo:AEntity
    {
        public Ufo(Point pos, Size size) : base(pos, size)
        {
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
