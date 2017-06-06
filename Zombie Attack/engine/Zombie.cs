using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engine
{
    public class Zombie : Mob
    {


        public Zombie(int i, string n, Position p)
        {
            id = i;
            name = n;
            pos = p;
        }
    }
}
