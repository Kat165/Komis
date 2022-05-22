using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Komis
{
    public partial class Szukaj : Form
    {
        public static List<Car> cars = new List<Car>();

        public static int selectedId = -1;
        CarList carList = new CarList();
        public Szukaj()
        {
            InitializeComponent();
            cars = carList.GetList();
            ComboxInit();
        }

        public void ComboxInit()
        {
            string[] marka = new string[cars.Count];
            string[] m;
            for(int i = 0; i< cars.Count; ++i)
            {
                marka[i] = cars[i].marka;
            }
            m = marka.Distinct().ToArray();
            foreach (var item in m)
            {
                comboBox1.Items.Add(item);
            }
           
            comboBox2.Enabled = false;


            for (int i = 0; i <= 500; i = i + 20)
            {
                comboBox3.Items.Add(i.ToString());
            }

            string[] kolor = new string[cars.Count];
            string[] k;
            for (int i = 0; i < cars.Count; ++i)
            {
                kolor[i] = cars[i].kolor;
            }
            k = kolor.Distinct().ToArray();
            foreach (var item in k)
            {
                comboBox4.Items.Add(item);
            }


            comboBox5.Items.Add("Tak");
            comboBox5.Items.Add("Nie");

            for (int i = 0; i < 73; i++)
            {
                int r = 1950 + i;
                comboBox6.Items.Add(r.ToString());
            }

            comboBox7.Items.Add("Tak");
            comboBox7.Items.Add("Nie");

            
            comboBox8.Items.Add("0");
            comboBox8.Items.Add("50000");
            comboBox8.Items.Add("100000");
            comboBox8.Items.Add("200000");
            comboBox8.Items.Add("300000");
            comboBox8.Items.Add("400000");
            comboBox8.Items.Add("500000");
            comboBox8.Items.Add("600000");


            string[] paliwo = new string[cars.Count];
            string[]p;
            for (int i = 0; i < cars.Count; ++i)
            {
                paliwo[i] = cars[i].paliwo;
            }
            p = paliwo.Distinct().ToArray();
            foreach (var item in p)
            {
                comboBox9.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox2.SelectedItem = null;
            comboBox2.Text = "";


            string[] s = new string[cars.Count];
            int j = 0;

            foreach (var item in cars)
            {
                if (comboBox1.Text == item.marka)
                {
                    s[j] = item.model;
                    j++;
                }
            }
            j = 0;
            s = s.Distinct().ToArray();
            foreach(var item in s)
            {
                if(item!= "" && item != null)
                {
                    comboBox2.Items.Add(item);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.SelectedItem = null;
            comboBox4.Text = "";
            string[] c = new string[cars.Count];
            int j = 0;

            foreach (var item in cars)
            {
                if (comboBox2.Text == item.model)
                {
                    c[j] = item.kolor;
                    j++;
                }
            }
            j = 0;
            c = c.Distinct().ToArray();
            foreach (var item in c)
            {
                if (item != "" && item != null)
                {
                    comboBox4.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = carList.GetDataTable();

            int przebieg = -1;
            int cena = -1;
            if(comboBox8.Text != "")
                przebieg = int.Parse(comboBox8.Text);
            if(comboBox3.Text != "")
                cena = int.Parse(comboBox3.Text);

            dt.DefaultView.RowFilter = carList.Filter(comboBox1.Text,comboBox2.Text,comboBox4.Text,comboBox5.Text,
                przebieg, comboBox9.Text,cena,comboBox6.Text,comboBox7.Text);

            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                dataGridView1.ClearSelection();
                return;
            }
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            selectedId = int.Parse(row.Cells["ID"].Value.ToString());

            Zdjecie zdjecie = new Zdjecie();
            zdjecie.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Najpierw wybierz auto!");
                return;
            }
            Rezerwuj rezerwuj = new Rezerwuj();
            rezerwuj.Show();
        }

    }
    
}