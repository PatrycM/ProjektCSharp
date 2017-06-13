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
        int lives;

        public Player()
        {
        }

        public Player(int a, int b)
        {
            lives = a;
            gold = b;
        }

        public void SetGold(int a) { this.gold = a; }
        public int GetGold() { return this.gold; }

        public void SetLives(int a) { this.lives = a; }
        public int GetLives() { return this.lives; }

    }
}
