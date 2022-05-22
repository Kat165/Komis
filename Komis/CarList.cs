using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Buduje listę i datatable dostępnych samochodów z pliku csv i filtruje ich zawartość
 */


namespace Komis
{
    internal class CarList
    {
        private List<Car> cars = new List<Car>();
        readonly string path = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\carscsv.csv";
        private DataTable dt = new DataTable();
        public CarList()
        {
            dt.Columns.Add("Marka");
            dt.Columns.Add("Model");
            dt.Columns.Add("Kolor");
            dt.Columns.Add("Uzywany");
            dt.Columns.Add("Przebieg");
            dt.Columns.Add("Paliwo");
            dt.Columns.Add("Cena");
            dt.Columns.Add("Rok produkcji");
            dt.Columns.Add("Uszkodzony");
            dt.Columns.Add("ID");

            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] totalData = new string[File.ReadAllLines(path).Length];
                totalData = streamReader.ReadLine().Split(',');
                while (!streamReader.EndOfStream)
                {
                    totalData = streamReader.ReadLine().Split(',');

                    cars.Add(new Car(totalData[0], totalData[1], totalData[2], totalData[3], int.Parse(totalData[4]), totalData[5],
                        int.Parse(totalData[6]), int.Parse(totalData[7]), totalData[8], int.Parse(totalData[9])));

                    dt.Rows.Add(totalData[0], totalData[1], totalData[2], totalData[3], totalData[4], totalData[5],
                    totalData[6], totalData[7], totalData[8], totalData[9]);

                }

                cars = cars.OrderByDescending(i => i.marka).ToList();
                streamReader.Close();
            }
        }
        
        public string Filter(string marka, string model, string kolor, string uzywany, long przebieg, string paliwo, long cena,
            string rok_prod, string uszkodzony)
        {
            string[] filters = { "", "", "", "", "", "", "", "", "" };
            if (marka != "")
            {
                filters[0] = "[Marka] like '%" + marka + "%'";
            }

            if (model != "")
            {
                filters[1] = "[Model] like '%" + model + "%'";
            }

            if (kolor != "")
            {
                filters[2] = "[Kolor] like '%" + kolor + "%'";
            }

            if (uzywany != "")
            {
                filters[3] = "[Uzywany] like '%" + uzywany + "%'";
            }

            if (przebieg != -1)
            {
                filters[4] = "[Przebieg] <= " + przebieg;
            }
            if (paliwo != "")
            {
                filters[5] = "[Paliwo] like '%" + paliwo + "%'";
            }

            if (cena != -1)
            {
                filters[6] = "[Cena] <= " + cena * 1000;
            }

            if (rok_prod != "")
            {
                filters[7] = "[Rok produkcji] like '%" + rok_prod + "%'";
            }

            if (uszkodzony != "")
            {
                filters[8] = "[Uszkodzony] like '%" + uszkodzony + "%'";
            }

            StringBuilder filter = new StringBuilder();


            foreach (string f in filters)
            {
                if (f != "")
                {
                    if (filter.Length == 0)
                    {
                        filter.Append(f);
                    }
                    else if (filter.Length > 0)
                    {
                        filter.Append(" and " + f);
                    }
                }

            }
            return filter.ToString();
        }

        public List<Car> GetList()
        {
            return cars;
        }

        public DataTable GetDataTable()
        {
            return dt;
        }
    }
}
