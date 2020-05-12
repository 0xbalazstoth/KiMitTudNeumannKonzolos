using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiMitTudNeumann2020Minta
{
    class Ki
    {
        public static List<Ki> Adat = new List<Ki>();
        public int Sor;
        public string Nev;
        public string PontokTel;
        public int[] Pontok { get; set; }

        public static int megadottFordulo = 1;

        public Ki(int sor, string nev, string pontokTel, int[] pontok)
        {
            Sor = sor;
            Nev = nev;
            PontokTel = pontokTel;
            Pontok = pontok;
        }

        public static void F2(string fajl)
        {
            int sor = 0;
            using (StreamReader olvas = new StreamReader(fajl))
            {
                while (!olvas.EndOfStream)
                {
                    sor++;

                    string[] split = olvas.ReadLine().Split(';');
                    string nev = split[0];
                    string pontokTel = split[1];
                    int[] pontok = split[1].Split().Select(x => int.Parse(x)).ToArray();

                    Ki ki = new Ki(sor, nev, pontokTel, pontok);
                    Adat.Add(ki);
                }
            }
        }

        public static void F3() => Console.WriteLine($"3. feladat: A versenyen {Adat.Count} versenyző vett részt.");

        public static void F4()
        {
            Console.Write("4. feladat: Kérem a zsűritag sorszámát: ");
            megadottFordulo = Convert.ToInt32(Console.ReadLine());
        }

        public static void F5()
        {
            int elertPontok = 0;
            int db = 0;

            for (int i = 0; i < Adat.Count; i++)
            {
                elertPontok += Convert.ToInt32(Adat[i].Pontok[megadottFordulo - 1]);
                db++;
            }

            Console.WriteLine($"5. feladat: A zsűritag által adott pontszámok átlaga: {Math.Round((double)elertPontok / (double)db, 1)}");
        }

        public int Osszpont
        {
            get
            {
                return Pontok.Sum() - Pontok.Min() - Pontok.Max();
            }
        }

        public override string ToString()
        {
            return $"{Nev};{String.Join(" ", Pontok)}";
        }

        public static void F6()
        {
            int max = Adat.Max(x => x.Osszpont);
            Console.WriteLine($"6. feladat: A legmagasabb pontszámot elért versenyző: {Adat.First(x => x.Osszpont == max).Nev}. Pontszáma: {max}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ki.F2(@"selejtezo.txt");
            Ki.F3();
            Ki.F4();
            Ki.F5();
            Ki.F6();

            Console.ReadKey();
        }
    }
}
