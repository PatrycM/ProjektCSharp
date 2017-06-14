using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace Zombie_Attack
{

    public partial class Form1 : Form
    {
        Player player_;

        public Form1()
        {
            InitializeComponent();

            player_ = new Player(2, 0);

            //character view settings
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;

            //interface labels
            lbl_lives.Text = player_.GetLives().ToString();
            lbl_gold.Text = player_.GetGold().ToString();
            lbl_difficulty.Text = difficulty.ToString();

            //keyboard events
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            //Zombie Spawn
            timer1.Interval = 5000; //spawn frequency
            timer1.Tick += new System.EventHandler(this.Zombie_Spawn);
            timer1.Start();

        }

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();

        int current = 1; //direction count variable
        int c = 0; //animation count variable
        int b = 1; //count of bullets
        int direction = 0; //direction of player
        int difficulty = 1; //difficulty level
        bool keypressed = false;

        //keyboard events
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled)
                return;

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
                direction = 2;
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
                direction = 1;
            }
            //character movement DOWN
            if (e.KeyChar == 's' && pictureBox2.Location.Y < 384)
            {
                if (current == 0)
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
                direction = 0;
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
                direction = 3;
            }
            //fire
            if (e.KeyChar == 'p' && keypressed == false)
            {
                Bullet_Create(b);
                b++;
                keypressed = false;
            }
        }

        //Monster spawning
        Random rand = new Random(); //new object to make pseudorandom integers
        PictureBox[] pic_zombie = new PictureBox[2000];

        int[] current_z = new int[2000];

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
            this.Controls.Add(this.pic_zombie[k]);
            pic_zombie[k].BringToFront();
            pic_zombie[k].BackColor = Color.Transparent;
            pic_zombie[k].Parent = pictureBox1;
            movable[k] = true;
            current_z[k] = new int();
        }

        int i = 1;

        private void Zombie_Spawn(object sender, EventArgs e)
        {
            if (i <= 2000)
            {
                Zombie_Create(i);
                if (i == 1) //starts a timer after first zombie spawned
                {
                    //Zombie Move
                    timer2.Interval = 200;
                    timer2.Tick += new System.EventHandler(this.Zombie_Move);
                    timer2.Start();
                }
                i++;
            }
        }

        //zombie moving
        private void Zombie_Step(int r)
        {
            int mov_x = 0, mov_y = 0, dist_x = 0, dist_y = 0;

            dist_x = pic_zombie[r].Location.X - pictureBox2.Location.X;
            dist_y = pic_zombie[r].Location.Y - pictureBox2.Location.Y;

            if (dist_x > 0)
            {
                mov_x = -4;
            }
            if (dist_x < 0)
            {
                mov_x = 4;
            }
            if (dist_x == 0)
            {
                mov_x = 0;
            }

            if (dist_y > 0)
            {
                mov_y = -4;
            }
            if (dist_y < 0)
            {
                mov_y = 4;
            }
            if (dist_y == 0)
            {
                mov_y = 0;
            }

            if (((dist_x == 32 || dist_x == -32) && (dist_y == 32 || dist_y == -32)) || ((dist_x == 32 || dist_x == -32) && dist_y==0) || (dist_x == 0 && (dist_y == 32 || dist_y == -32)))
            {
                PlayerDeath();
            }
            else
            {
                pic_zombie[r].Location = new Point(pic_zombie[r].Location.X + mov_x, pic_zombie[r].Location.Y + mov_y);

                if (dist_x > 0 && dist_y > 0)
                {
                    int c = 0;
                    if(current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                if (dist_x > 0 && dist_y == 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                if (dist_x > 0 && dist_y < 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_left_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                ///
                if (dist_x < 0 && dist_y > 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                if (dist_x < 0 && dist_y == 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                if (dist_x < 0 && dist_y < 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_right_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                ///
                if (dist_x == 0 && dist_y > 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_up;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_up_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zombie_up_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }
                if (dist_x == 0 && dist_y < 0)
                {
                    int c = 0;
                    if (current_z[r] == 0)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_0;
                        c = 1;
                    }
                    if (current_z[r] == 1)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_0_1;
                        c = 2;
                    }
                    if (current_z[r] == 2)
                    {
                        pic_zombie[r].Image = global::Zombie_Attack.Properties.Resources.zom_0_2;
                        c = 0;
                    }
                    current_z[r] = c;
                }

            }
        }


        bool[] movable = new bool[2000];

        private void Zombie_Move(object sender, EventArgs e)
        {
            for(int r = 1; r<i; r++)
            {
                if (movable[r] == true)
                {
                    Zombie_Step(r);
                }
            }
        }

        private void PlayerDeath()
        {
            timer1.Stop();
            timer2.Stop();

            if(player_.GetLives() - 1 < 0)
            {
                GameOver();
            }
            else
            {
                Form1 newform = new Form1();
                newform.Show();
                newform.player_.SetLives(player_.GetLives() - 1);
                newform.lbl_lives.Text = newform.player_.GetLives().ToString();
                newform.player_.SetGold(player_.GetGold());
                newform.lbl_gold.Text = newform.player_.GetGold().ToString();
                this.Close();
            }
            

        }

        private void GameOver()
        {
            Form3 newform = new Form3();
            using(StreamWriter writetext = new StreamWriter("score.txt"))
            {
                writetext.WriteLine(player_.GetGold().ToString());
            }
            newform.Show();
            this.Close();
        }

        PictureBox[] bullet = new PictureBox[20000];
        int[] b_direction = new int[20000];

        private void Bullet_Create(int o)
        {
            if(o == 1)
            {
                timer3.Interval = 5; //bullet velocity
                timer3.Tick += new System.EventHandler(this.Bullet_Move);
                timer3.Start();
            }
            bullet[o] = new PictureBox();
            b_direction[o] = new int();

            bullet_movable[o] = true;
            b_direction[o] = direction;
            bullet[o].Location = pictureBox2.Location;
            bullet[o].Image = global::Zombie_Attack.Properties.Resources.bullet2;
            this.Controls.Add(this.bullet[o]);
            bullet[o].BringToFront();
            bullet[o].BackColor = Color.Transparent;
            bullet[o].Parent = pictureBox1;
        }

        private void Bullet_Step(int o)
        {
            if (b_direction[o] == 0)
            {
                bullet[o].Location = new Point(bullet[o].Location.X, bullet[o].Location.Y+4);
            }
            if (b_direction[o] == 1)
            {
                bullet[o].Location = new Point(bullet[o].Location.X-4, bullet[o].Location.Y);
            }
            if (b_direction[o] == 2)
            {
                bullet[o].Location = new Point(bullet[o].Location.X, bullet[o].Location.Y-4);
            }
            if (b_direction[o] == 3)
            {
                bullet[o].Location = new Point(bullet[o].Location.X+4, bullet[o].Location.Y);
            }

        }

        bool[] bullet_movable = new bool[20000];
        private void Bullet_Move(object sender, EventArgs e)
        {
            for (int m = 1; m<b; m++)
            {
                if(bullet_movable[m])
                {
                    Bullet_Step(m);
                }
                for (int a = 1; a<i; a++)
                {
                    if(bullet[m].Location == pic_zombie[a].Location)
                    {
                        pic_zombie[a].Location = new Point(1000, 1000);
                        pic_zombie[a].Image = null;
                        movable[a] = false;

                        bullet[m].Location = new Point(1001, 1001);
                        bullet[m].Image = null;
                        bullet_movable[m] = false;

                        player_.SetGold(player_.GetGold() + 10);
                        lbl_gold.Text = player_.GetGold().ToString();
                        if(player_.GetGold() == 50)
                        {
                            timer1.Interval = 2000;
                            timer2.Interval = 180;
                            difficulty = 2;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 100 && player_.GetGold() < 150)
                        {
                            timer1.Interval = 1800;
                            timer2.Interval = 160;
                            difficulty = 3;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 150 && player_.GetGold() < 200)
                        {
                            timer1.Interval = 1600;
                            timer2.Interval = 140;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 200 && player_.GetGold() < 250)
                        {
                            timer1.Interval = 1400;
                            timer2.Interval = 120;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 250 && player_.GetGold() < 350)
                        {
                            timer1.Interval = 1200;
                            timer2.Interval = 100;
                            difficulty = 6;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 350 && player_.GetGold() < 450)
                        {
                            timer1.Interval = 1000;
                            timer2.Interval = 80;
                            difficulty = 7;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 450 && player_.GetGold() < 550)
                        {
                            timer1.Interval = 800;
                            timer2.Interval = 60;
                            difficulty = 8;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 550 && player_.GetGold() < 1000)
                        {
                            timer1.Interval = 600;
                            timer2.Interval = 40;
                            difficulty = 9;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                        if (player_.GetGold() >= 1000)
                        {
                            timer1.Interval = 400;
                            timer2.Interval = 30;
                            difficulty = 10;
                            lbl_difficulty.Text = difficulty.ToString();
                        }
                    }
                }
            }

        }

    }
}

// To do: 
// zaprojektować poziomy trudności
// highscores
