using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_08_Aufgabe_03
{
    struct Angestellter
    {
        public int id;
        public string nachname;
        public double gehalt;
    }
    class Program
    {
        static int id = 1;
        static void Main(string[] args)
        {
            Angestellter a1, a2;

            fuelleAngestellter(out a1, "Biden", 1337.69);
            fuelleAngestellter(out a2, "Trump", 0.01);

            Console.WriteLine("Ausgabe A1");
            ausgabeAngestellter(a1);
            Console.WriteLine("\nAusgabe A2");
            ausgabeAngestellter(a2);
            Console.ReadKey();
        }

        static void fuelleAngestellter(out Angestellter a, string name, double gehalt)
        {
            a.id = id++;
            a.nachname = name;
            a.gehalt = gehalt;
        }

        static void ausgabeAngestellter(Angestellter a)
        {
            Console.WriteLine($"ID -> {a.id}");
            Console.WriteLine($"Nachname -> {a.nachname}");
            Console.WriteLine($"Gehalt -> {Math.Round(a.gehalt, 2)}EUR");
        }
    }
}
