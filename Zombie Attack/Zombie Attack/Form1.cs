using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

            //Zombie Spawn
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000; //spawn frequency
            timer1.Tick += new System.EventHandler(this.Zombie_Spawn);
            timer1.Start();
            Stopwatch counter = new Stopwatch();
            counter.Start();

            //Zombie Move
            System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 200; //spawn frequency
            timer2.Tick += new System.EventHandler(this.Zombie_Step);
            if (counter.ElapsedMilliseconds >= 5000)
            {
                timer2.Start();
            }


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
            if (e.KeyChar == 's' && pictureBox2.Location.Y < 384)
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
        

        private void Zombie_Create(int k)
        {
            int set_x = 0;
            int set_y = 0;

            pic_zombie[k] = new PictureBox();
            int rand_area = rand.Next(1, 5); //map edge random

            //zombie location random
            if (rand_area == 1)
            {
                set_x = 192;
                set_y = 0;
            }
            if (rand_area == 2)
            {
                set_x = 0;
                set_y = 200;
            }
            if (rand_area == 3)
            {
                set_x = 368;
                set_y = 200;
            }
            if (rand_area == 4)
            {
                set_x = 192;
                set_y = 384;
            }

            pic_zombie[k].Location = new Point(set_x, set_y);
            pic_zombie[k].Image = global::Zombie_Attack.Properties.Resources.zom_0;
            this.Controls.Add(this.pic_zombie[i]);
            pic_zombie[k].BringToFront();
            pic_zombie[k].BackColor = Color.Transparent;
            pic_zombie[k].Parent = pictureBox1;
        }

        int i = 1;
   
        private void Zombie_Spawn(object sender, EventArgs e)
        {
            if (i < 20)
            {
                Zombie_Create(i);
                i++;
            }
        }

        //zombie moving
        private void Zombie_Step(object sender, EventArgs e)
        {
            for (int j = 1; j == 20; j++)
            {
                int move_x = 0;
                int move_y = 0;
                int dist_x = pic_zombie[j].Location.X - pictureBox2.Location.X;
                int dist_y = pic_zombie[j].Location.Y - pictureBox2.Location.Y;

                if (dist_x > 0)
                {
                    move_x = -4;
                }
                if (dist_x < 0)
                {
                    move_x = 4;
                }

                if (dist_y > 0)
                {
                    move_y = 4;
                }
                if (dist_y < 0)
                {
                    move_y = -4;
                }
                if (dist_x ==0 && dist_y ==0)
                {
                    player_.lives -= 1;
                }
                pic_zombie[j].Location = new Point(pic_zombie[j].Location.X+move_x, pic_zombie[j].Location.Y+move_y);
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
