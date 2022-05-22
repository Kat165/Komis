using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komis
{
    public class Car
    {
        public string marka;
        public string model;
        public string kolor;
        public string uzywany;
        public long przebieg;
        public string paliwo;
        public long cena;
        public int rok_prod;
        public string uszkodzony;
        public int id;

        public Car(string marka, string model, string kolor, string uzywany, long przebieg, string paliwo, long cena, int rok_prod, string uszkodzony, int id)
        {
            this.marka = marka;
            this.model = model;
            this.kolor = kolor;
            this.uzywany = uzywany;
            this.przebieg = przebieg;
            this.paliwo = paliwo;
            this.cena = cena;
            this.rok_prod = rok_prod;
            this.uszkodzony = uszkodzony;
            this.id = id;
        }

        public Car(string marka, string model)
        {
            this.marka = marka;
            this.model = model;
            //this.kolor = "";
            //this.uzywany = "";
            //this.przebieg = -1;
            //this.paliwo = "";
            //this.cena = -1;
            //this.rok_prod = -1;
            //this.uszkodzony = "";
            //this.id = -1;
        }
    }
}
