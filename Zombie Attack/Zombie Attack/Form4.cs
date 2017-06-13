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
    public partial class Form4 : Form
    {
        string newnickname;
        int score;
        public Form4()
        {
            InitializeComponent();

            FLoad();
        }

        public void Set_newnickname(string s) { newnickname = s; }
        public void Set_score(int i) { score = i; }

        private void FLoad()
        {
            if(score > Int32.Parse(score1.Text))
            {
                score1.Text = score.ToString();
                name1.Text = newnickname;
            }
            if (score > Int32.Parse(score2.Text))
            {
                score2.Text = score.ToString();
                name2.Text = newnickname;
            }
            if (score > Int32.Parse(score3.Text))
            {
                score3.Text = score.ToString();
                name3.Text = newnickname;
            }
        }
    }
}
