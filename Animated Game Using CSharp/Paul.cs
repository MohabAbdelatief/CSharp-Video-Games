using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Adventures_of_Paul
{
    internal class Paul
    {
        private int health = 100;
        public int X, Y;
        public bool GroundReached = false;
        public bool LadderHit = false;
        public bool onladder = false;
        public bool Jump = false;
        public bool JumpLimitReached = false;
        public bool Falling = false;
        public bool AttackMode = false;
        public bool LadderLimitReached = false;
        public bool HitElevator;
        public bool onElevator;
        public Bitmap image;

    }
}
