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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.MdiParent = this;
            newform.Show();
            newform.WindowState = FormWindowState.Maximized;
            newform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newform.ControlBox = false;
            newform.Text = String.Empty;


            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
    }
}
