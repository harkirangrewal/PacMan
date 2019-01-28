using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_FinalProject
{
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 MainForm = new Form1();
            MainForm.ShowDialog();
            this.Close();
        }
    }
}
