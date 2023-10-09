using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048alt
{
    public partial class F_Menu : Form
    {
        public F_Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ノーマル画面の表示
            Normal noraml = new Normal();
            noraml.Show(this);

            //メニュー画面の非表示
            Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //ノーマル画面の表示
            Division division = new Division();
            division.Show(this);

            //メニュー画面の非表示
            Hide();
        }
    }
}
