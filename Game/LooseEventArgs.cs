using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class LooseEventArgs:EventArgs
    {
        public UInt64 Score;

        public LooseEventArgs(UInt64 score)
        {
            Score = score;
        }
    }
}
