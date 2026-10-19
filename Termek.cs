using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace RaktarApp
{
    public class Termek
    {

        public string Cikkszam { get; set; }
        protected int alapar;

        public int Alapar
        {
            get { return alapar; }
            set
            {
                if(value <= 0)
                {
                    alapar = 1000;
                }
                else
                {
                    alapar = value;
                }
            }
        }
        private static int osszestermekszama;
        public static int OsszesTermekSzama
        {
            get { return osszestermekszama; }
        }

        public Termek(string beCikszam, int bealapar)
        {
            Cikkszam = beCikszam;
            alapar = bealapar;
            osszestermekszama++;
        }
        public virtual int ErtekSzamitas(int darabszam)
        {
            return Alapar * darabszam;
        }

        public override string ToString()
        {
            return $"Termék {Cikkszam}, Egységár {Alapar} Ft.";
        }



    }
}
