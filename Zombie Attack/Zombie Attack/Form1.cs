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

            //character view settings
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;

            //constructiong abstract objects
            location1 = new Location(11,11);
            start_pos = new Position(6,6);
            player_ = new Player(0,"Player",0,3,start_pos);

            //interface labels
            lbl_gold.Text = player_.gold.ToString();
            lbl_lives.Text = player_.lives.ToString();

            //keyboard events
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            //zombie spawn
            Zombie_Spawn();

        }

        int current = 1; //direction count variable
        int c = 0; //animation count variable

        //keyboard events
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //character movement UP
            if (e.KeyChar == 'w' && pictureBox2.Location.Y > 0)
            {
                if (current == 0)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_up_1;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 4);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_up_2;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 4);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_up;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 4);
                    c = 0;
                }
                current = c;
            }
            //character movement LEFT
            if (e.KeyChar == 'a' && pictureBox2.Location.X > 0)
            {
                if (current == 0)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_left_1;
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 4, pictureBox2.Location.Y);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_left_2;
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 4, pictureBox2.Location.Y);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_left;
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 4, pictureBox2.Location.Y);
                    c = 0;
                }
                current = c;
            }
            //character movement DOWN
            if (e.KeyChar == 's' && pictureBox2.Location.Y < 400)
            {
                if(current == 0)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_0_1;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 4);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_0_2;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 4);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_0;
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 4);
                    c = 0;
                }
                current = c;
            }
            //character movement RIGHT
            if (e.KeyChar == 'd' && pictureBox2.Location.X < 368)
            {
                if (current == 0)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_right_1;
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 4, pictureBox2.Location.Y);
                    c = 1;
                }
                if (current == 1)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_right_2;
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 4, pictureBox2.Location.Y);
                    c = 2;
                }
                if (current == 2)
                {
                    pictureBox2.Image = global::Zombie_Attack.Properties.Resources.char_right;
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 4, pictureBox2.Location.Y);
                    c = 0;
                }
                current = c;
            }
        }
        
        //Monster spawning
        Random rand = new Random(); //new object to make pseudorandom integers
        PictureBox[] pic_zombie = new PictureBox[20];

        private void Zombie_Spawn()
        {
            int set_x = 0;
            int set_y = 0;

            for (int i = 1; i <= 1; i++)
            {
                int rand_area = rand.Next(1, 5); //map edge random

                //zombie location random
                if (rand_area == 1)
                {
                    
                }
                if (rand_area == 2)
                {
                    
                }
                if (rand_area == 3)
                {
                    
                }
                if (rand_area == 4)
                {
                    
                }

                //pic_zombie[i].Location = new Point();
                //pic_zombie[i].Image = global::Zombie_Attack.Properties.Resources.zom_0;
                //this.Controls.Add(this.pic_zombie[i]);
                //pic_zombie[i].BringToFront();
                //pic_zombie[i].BackColor = Color.Transparent;
                //pic_zombie[i].Parent = pictureBox1;
            }
            //pic_zombie.Location = new Point(200, 200);
            //pic_zombie.Image = global::Zombie_Attack.Properties.Resources.zom_0;
            //this.Controls.Add(this.pic_zombie);
            //pic_zombie.BringToFront();
            //pic_zombie.BackColor = Color.Transparent;
            //pic_zombie.Parent = pictureBox1;
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