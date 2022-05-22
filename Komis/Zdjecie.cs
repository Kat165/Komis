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
    public partial class Zdjecie : Form
    {
        public Zdjecie()
        {
            InitializeComponent();
            Zdj();
        }

        private void Zdj()
        {
            string photopath = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\zdjecia\\"
                        + Szukaj.selectedId + ".jpg";
            pictureBox1.Load(photopath);
        }
    }
}
