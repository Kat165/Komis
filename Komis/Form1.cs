using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Komis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Szukaj szukaj = new Szukaj();
            this.Hide();
            szukaj.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dodaj dodaj = new Dodaj();
            this.Hide();
            dodaj.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Najpierw wybierz auto!");
            Szukaj szukaj = new Szukaj();
            this.Hide();
            szukaj.ShowDialog();
            this.Show();
        }
    }
}
