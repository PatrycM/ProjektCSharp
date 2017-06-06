using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engine
{
    public class Player : Mob
    {
        public int gold { get; set; }
        public int lives { get; set; }

        public Player(int i, string n, int g, int l, Position p)
        {
            id = i;
            name = n;
            gold = g;
            lives = l;
            pos = p;
        }
    }
}
