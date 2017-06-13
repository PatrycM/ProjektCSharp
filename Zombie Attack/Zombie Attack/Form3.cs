using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie_Attack
{
    public partial class Form3 : Form
    {
        int score;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newform = new Form4();
            newform.Show();
            newform.Set_newnickname(textBox1.Text);
            newform.Set_score(score);
            this.Close();
        }

        public void get_score(int a) { score = a; }
    }
}
