using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engine
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int a, int b)
        {
            x = a;
            y = b;
        }
    }
}
