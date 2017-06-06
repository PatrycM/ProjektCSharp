using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using engine;

namespace Zombie_Attack
{
    public partial class Form1 : Form
    {
        private Player player1;
        public Form1()
        {
            InitializeComponent();

            player1 = new Player();

            player1.gold = 0;
            player1.lives = 3;

            lbl_gold.Text = player1.gold.ToString();
            lbl_lives.Text = player1.lives.ToString();
        }
    }
}
