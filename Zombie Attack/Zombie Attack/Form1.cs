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
        private Player player_;
        private Location location1;
        private Position start_pos;
        public Form1()
        {
            InitializeComponent();
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;

            location1 = new Location(11,11);
            start_pos = new Position(6,6);
            player_ = new Player(0,"Player",0,3,start_pos);

            lbl_gold.Text = player_.gold.ToString();
            lbl_lives.Text = player_.lives.ToString();

            KeyPress += new KeyPressEventHandler(Form1_KeyPress);

        }

        int current=1;

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = 0;
            if (e.KeyChar == 'w' && pictureBox2.Location.Y > 50)
            {
                if (current == 0)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_up_1.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 5);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_up_2.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 5);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_up.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 5);
                    c = 0;
                }
                current = c;
            }
            if (e.KeyChar == 'a' && pictureBox2.Location.X > 50)
            {
                if (current == 0)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_left_1.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_left_2.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_left.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
                    c = 0;
                }
                current = c;
            }
            if (e.KeyChar == 's' && pictureBox2.Location.Y < 420)
            {
                if(current == 0)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_0_1.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 5);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_0_2.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 5);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_0.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 5);
                    c = 0;
                }
                current = c;
            }
            if (e.KeyChar == 'd' && pictureBox2.Location.X < 400)
            {
                if (current == 0)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_right_1.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_right_2.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Zombie Attack/Resources/char_right.png";
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
                    c = 0;
                }
                current = c;
            }
        }
    }
}

// To do: 
// zmienić tak, żeby position robiło wszystko, a nie img location 
// dorzucić ruch potworów i wymyślić im random walk
// bounce enemy<=>player (lives)
// zanimować pociski
// bounce missile<=>enemy (gold)
// zaprojektować poziomy trudności
// zaprojektować GUI
// highscores