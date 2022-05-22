using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Tworzy listę do dodawania, dodaje auta
 */

namespace Komis
{

    internal class DCars
    {
        List<Car> all_posible_cars = new List<Car>();
        readonly private string allcars_path = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\allcars.csv";
        readonly private string photo_path = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\zdjecia.csv";
        readonly private string path = "C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\carscsv.csv";
        public DCars()
        {
            using(StreamReader streamReadercars = new StreamReader(allcars_path))
            {
                string[] totalDatacars = new string[File.ReadAllLines(allcars_path).Length];
                totalDatacars = streamReadercars.ReadLine().Split(',');
                while (!streamReadercars.EndOfStream)
                {
                    totalDatacars = streamReadercars.ReadLine().Split(',');
                    all_posible_cars.Add(new Car(totalDatacars[1], totalDatacars[0]));
                }
                streamReadercars.Close();

            }

        }

        public void addPhoto(string marka, string model, string kolor, string uzywany, string przebieg, string paliwo,
            string cena, string rok_prod, string uszkodzony, string added_photo_path)
        {
            CarList carlist = new CarList();
            int id = carlist.GetList().Count();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(marka + "," + model + "," + kolor + "," + uzywany + "," + przebieg + "," +
                    paliwo + "," + cena + "," + rok_prod + "," + uszkodzony + "," + id);
                sw.Close();
            }


            string new_photo = @"C:\\Users\\kasia\\source\\repos\\Komis\\Komis\\pliki\\zdjecia\\" + id + ".jpg";
            File.Move(added_photo_path, new_photo);

            using (StreamWriter sw = File.AppendText(photo_path))
            {
                sw.WriteLine(id + "," + new_photo);
                sw.Close();
            }

        }

        public List<Car> GetAllCars()
        {
            return all_posible_cars;
        }
    }
}
