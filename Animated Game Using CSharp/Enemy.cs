using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Adventures_of_Paul
{
    internal class Enemy
    {
        public Point point;
        public Bitmap image;
        public bool left, right;
        public bool AttackPlayer;
        public bool BulletHitMe = false;
        public bool BulletHitMe2 = false;
        public bool laserHitMe = false;
        public bool isDead;
    }
}
