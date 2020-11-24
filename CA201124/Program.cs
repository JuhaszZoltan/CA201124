using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201124
{
    struct Egitest
    {
        public string Nev;
        public string Kering;
        public long Tavolsag;
        public int Atmero;

        public Egitest(string nev, string kering, long tavolsag, int atmero)
        {
            Nev = nev;
            Kering = kering;
            Tavolsag = tavolsag;
            Atmero = atmero;
        }
    }
    class Program
    {
        static Egitest[] egitestek = new Egitest[70];

        static void Main()
        {
            Beolvasas();
            F01();
            F02();
            F03();
            F04();
            F05();

            Console.ReadKey(true);
        }

        private static void F05()
        {
            var jupiterHoldjai = new List<Egitest>();

            foreach (var e in egitestek)
            {
                if (e.Kering == "Jupiter") jupiterHoldjai.Add(e);
            }

            for (int i = 0; i < jupiterHoldjai.Count - 1; i++)
            {
                for (int j = i + 1; j < jupiterHoldjai.Count; j++)
                {
                    if(jupiterHoldjai[i].Tavolsag > jupiterHoldjai[j].Tavolsag)
                    {
                        var s = jupiterHoldjai[i];
                        jupiterHoldjai[i] = jupiterHoldjai[j];
                        jupiterHoldjai[j] = s;
                    }
                }
            }

            var sw = new StreamWriter(@"..\..\Res\jupiter.txt");

            foreach (var e in jupiterHoldjai)
            {
                sw.WriteLine("{0, -8} {1} {2,8} {3}", e.Nev, e.Kering, e.Tavolsag, e.Atmero);
            }
            sw.Close();
        }

        private static void F04()
        {
            Console.WriteLine("Naprendszerünk bolygói:");
            foreach (var e in egitestek)
            {
                if (e.Kering == "Nap") Console.WriteLine($"\t{e.Nev}");
            }
        }

        private static void F03()
        {
            int c = 0;

            foreach (var e in egitestek)
            {
                if (e.Kering == "Neptunusz") c++;
            }

            Console.WriteLine($"A neptunusznak {c} holdja van");
        }

        private static void F02()
        {
            int maxi = 0;

            for (int i = 1; i < egitestek.Length; i++)
            {
                if (egitestek[i].Atmero > egitestek[maxi].Atmero) maxi = i;
            }

            Console.WriteLine($"Legnagyobb átmérőjű égitest: {egitestek[maxi].Nev}");
        }

        private static void F01()
        {
            int sum = 0;
            foreach (var e in egitestek)
            {
                sum += e.Atmero;
            }
            Console.WriteLine($"Átlagos átmérő: {sum / (float)egitestek.Length}");
        }

        private static void Beolvasas()
        {
            var sr = new StreamReader(@"..\..\Res\egitestek.txt");
            for (int i = 0; i < egitestek.Length; i++)
            {
                string[] sor = sr.ReadLine().Split(' ');
                egitestek[i] = new Egitest(sor[0], sor[1], long.Parse(sor[2]), int.Parse(sor[3]));
            }
            sr.Close();
        }
    }
}
