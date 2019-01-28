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
    public partial class Introduction_Form : Form
    {
        public Introduction_Form()
        {
            InitializeComponent();
        }

        private void btnGotIt_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Introduction_Form = new Form1();
            Introduction_Form.ShowDialog();
            this.Close();
        }
    }
}
