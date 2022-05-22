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
    public partial class Rezerwuj : Form
    {
        string terminy_path = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\terminy.csv";
        DataTable dt = new DataTable();
        
        public Rezerwuj()
        {
            InitializeComponent();
            monthCalendar1.MinDate = DateTime.Now;
            monthCalendar1.MaxDate = DateTime.Now.AddDays(60);
            Terminy();
        }

        private void Terminy()
        {
            StreamReader streamReader = new StreamReader(terminy_path);
            string[] totalData = new string[File.ReadAllLines(terminy_path).Length];
            dt.Columns.Add("ID");
            dt.Columns.Add("Zajęte terminy");
            dt.Columns.Add("Imię");
            totalData = streamReader.ReadLine().Split(',');
            while (!streamReader.EndOfStream)
            {
                totalData = streamReader.ReadLine().Split(',');
                dt.Rows.Add(totalData[0], totalData[1], totalData[2]);
            }

            string filter = "[ID] like '%" + Szukaj.selectedId + "%'";
            dt.DefaultView.RowFilter = filter;
            dt.Columns["ID"].ColumnMapping = MappingType.Hidden;
            DataView dv = dt.DefaultView;
            dv.Sort = "Zajęte terminy";

            dataGridView1.DataSource = dv;
            streamReader.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show(monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy"));
            if(textBox1.Text == "")
            {
                MessageBox.Show("Podaj imie");
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString().Equals(monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy")) 
                    && Szukaj.selectedId == int.Parse(dt.Rows[i][0].ToString()))
                {
                    MessageBox.Show("Wybierz inny termin", "Zajęte");
                    return;
                }
            }
            using (StreamWriter sw = File.AppendText(terminy_path))
            {
                sw.WriteLine(Szukaj.selectedId + "," + monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy") + "," + textBox1.Text);
                sw.Close();
            }
            dt.Rows.Add(Szukaj.selectedId, monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy"),textBox1.Text);
           
            DataView dv = dt.DefaultView;
            dv.Sort = "Zajęte terminy";

            dataGridView1.DataSource = dv;
        }
    }
}
