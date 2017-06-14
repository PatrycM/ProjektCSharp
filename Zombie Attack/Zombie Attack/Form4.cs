using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Zombie_Attack
{
    public partial class Form4 : Form
    {
        string newnickname;
        int score;

        public Form4()
        {
            InitializeComponent();

            if(File.Exists("score.txt") == true)
            {
                using (StreamReader readtext = new StreamReader("score.txt"))
                {
                    string readMeText = readtext.ReadLine();
                    score = Int32.Parse(readMeText);
                }
            }

            if (File.Exists("newnickname.txt") == true)
            {
                using (StreamReader readtext = new StreamReader("newnickname.txt"))
                {
                    string readMeText = readtext.ReadLine();
                    newnickname = readMeText;
                }
                File.Delete("score.txt");
                File.Delete("newnickname.txt");
            }

            FLoad();
        }


        private void FLoad()
        {
            string[] names = File.ReadAllLines("nicknames.txt");
            string[] scores = File.ReadAllLines("scores.txt");

            name1.Text = names[0];
            score1.Text = scores[0];
            name2.Text = names[1];
            score2.Text = scores[1];
            name3.Text = names[2];
            score3.Text = scores[2];

            int gold1 = Int32.Parse(score1.Text);
            int gold2 = Int32.Parse(score2.Text);
            int gold3 = Int32.Parse(score3.Text);

            if (score!=0 && newnickname != null)
            {
                if (score > gold1)
            {
                score3.Text = score2.Text;
                name3.Text = name2.Text;

                score2.Text = score1.Text;
                name2.Text = name1.Text;

                score1.Text = score.ToString();
                name1.Text = newnickname;
            }
            if (score > gold2 && score <= gold1)
            {
                score3.Text = score2.Text;
                name3.Text = name2.Text;

                score2.Text = score.ToString();
                name2.Text = newnickname;
            }
            if (score > gold3 && score < gold2)
            {
                score3.Text = score.ToString();
                name3.Text = newnickname;
            }
            if (gold3 == 0 && score == gold2)
                {
                    score3.Text = score.ToString();
                    name3.Text = newnickname;
                }

            File.Delete("newnicknames.txt");
            File.Delete("scores.txt");

            using (StreamWriter writetext = new StreamWriter("nicknames.txt"))
            {
                writetext.WriteLine(name1.Text);
                writetext.WriteLine(name2.Text);
                writetext.WriteLine(name3.Text);
            }
            using (StreamWriter writetext = new StreamWriter("scores.txt"))
            {
                writetext.WriteLine(score1.Text);
                writetext.WriteLine(score2.Text);
                writetext.WriteLine(score3.Text);
            }
            }

        }
    }
}
