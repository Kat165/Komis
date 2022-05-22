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
    public partial class Dodaj : Form
    {
        string added_photo_path;
        readonly string[] kolory = { "Czarny", "Bialy", "Szary", "Srebrny", "Czerwony", "Pomaranczowy", "Zolty", 
            "Brazowy", "Bezowy", "Zloty", "Niebieski", "Zielony", "Fioletowy", "Rozowy", "Granatowy", "Inny" };
        readonly string[] paliwa = { "Benzyna", "Gaz", "Diesel", "Elektryczny", "Hybryda" };

        List<Car> all_posible_cars = new List<Car>();

        DCars dCars = new DCars();

        public Dodaj()
        {
            InitializeComponent();
            all_posible_cars = dCars.GetAllCars();
            ComboBoxInit();
        }

        private void ComboBoxInit()
        {
            string[] allc = new string[all_posible_cars.Count];
            string[] wszystkie_marki;
            if(all_posible_cars.Count > 0)
            {
                for(int i = 0; i < all_posible_cars.Count; i++)
                {
                    allc[i] = all_posible_cars[i].marka;
                }
            }
            wszystkie_marki = allc.Distinct().ToArray();

            foreach(string c in wszystkie_marki)
            {
                comboBox1.Items.Add(c);
            }

            
            foreach(string item in kolory)
            {
                comboBox3.Items.Add(item);
            }

            comboBox4.Items.Add("Tak");
            comboBox4.Items.Add("Nie");

            foreach(string item in paliwa)
            {
                comboBox5.Items.Add(item);
            }
            
            for(int i = 2022; i > 1900; --i)
            {
                comboBox6.Items.Add(i);
            }

            comboBox7.Items.Add("Tak");
            comboBox7.Items.Add("Nie");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || 
                comboBox4.Text == "" || textBox5.Text == "" || comboBox5.Text == "" || 
                textBox7.Text == "" || comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie dane!");
                return;
            }

            if (!int.TryParse(textBox5.Text, out _))
            {
                MessageBox.Show("Przebieg musi być liczbą");
                return;
            }
            if (!int.TryParse(textBox7.Text, out _))
            {
                MessageBox.Show("Cena musi być liczbą");
                return;
            }
            

            if (added_photo_path == null)
            {
                MessageBox.Show("Dodaj zdjęcie!");
                return;
            }

            dCars.addPhoto(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, textBox5.Text, comboBox5.Text,
                textBox7.Text, comboBox6.Text, comboBox7.Text, added_photo_path);

            MessageBox.Show("Dodano auto!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;)|*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                added_photo_path = opnfd.FileName;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox2.SelectedItem = null;
            comboBox2.Text = "";

            string[] s = new string[all_posible_cars.Count];
            int j = 0;

            foreach (var item in all_posible_cars)
            {
                if (comboBox1.Text == item.marka)
                {
                    s[j] = item.model;
                    j++;
                }
            }
            j = 0;
            s = s.Distinct().ToArray();
            foreach (var item in s)
            {
                if (item != "" && item != null)
                {
                    comboBox2.Items.Add(item);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            comboBox1.Text = "";
            comboBox2.SelectedItem = null;
            comboBox2.Text = "";
            comboBox3.SelectedItem = null;
            comboBox3.Text = "";
            comboBox4.SelectedItem = null;
            comboBox4.Text = "";
            comboBox5.SelectedItem = null;
            comboBox5.Text = "";
            comboBox6.SelectedItem = null;
            comboBox6.Text = "";
            comboBox7.SelectedItem = null;
            comboBox7.Text = "";

            textBox5.Text = "";
            textBox7.Text = "";
        }
    }
}
