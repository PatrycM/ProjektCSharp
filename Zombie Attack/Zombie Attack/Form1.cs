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

            location1 = new Location(11,11);
            start_pos = new Position(6,6);
            player_ = new Player(0,"Player",0,3,start_pos);

            lbl_gold.Text = player_.gold.ToString();
            lbl_lives.Text = player_.lives.ToString();

            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' && pictureBox2.Location.Y > 50)
            {
                pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_up.png";
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 5);
            }
            if (e.KeyChar == 'a' && pictureBox2.Location.X > 50)
            {
                pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_left.png";
                pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
            }
            if (e.KeyChar == 's' && pictureBox2.Location.Y < 420)
            {
                pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_0.png";
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 5);
            }
            if (e.KeyChar == 'd' && pictureBox2.Location.X < 400)
            {
                pictureBox2.ImageLocation = "C:/Users/Patrycjusz/Source/Repos/ProjektCSharp/Zombie Attack/Sprites/char_right.png";
                pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
            }
        }
    }
}

// To do: 
// wrzucić sprity i teksturę na gita + dodać animacje + transparentność!
// zmienić tak, żeby position robiło wszystko, a nie img location 
// dorzucić ruch potworów i wymyślić im random walk
// bounce enemy<=>player (lives)
// zanimować pociski
// bounce missile<=>enemy (gold)
// zaprojektować poziomy trudności
// zaprojektować GUI
// highscores