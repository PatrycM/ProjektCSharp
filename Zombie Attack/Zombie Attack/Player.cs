using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Attack
{
    public class Player
    {
        int gold;

        public Player()
        {
        }

        public Player(int a)
        {
            gold = a;
        }

        public void SetGold(int a) { this.gold = a; }
        public int GetGold() { return this.gold; }

    }
}
