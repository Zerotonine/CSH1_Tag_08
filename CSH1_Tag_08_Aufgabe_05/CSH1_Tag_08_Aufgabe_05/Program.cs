using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_08_Aufgabe_05
{
    #region STRUCTURE
    struct Messung
    {
        public string bezeichnung;
        public int wertA;
        public double wertB;
        public DateTime datum;
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            List<Messung> messung = new List<Messung>();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("1 - Messung eingeben");
                Console.WriteLine("2 - Messung ausgeben");
                Console.WriteLine("ESC - Beenden");
                
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        messung.Add(Eingabe());
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Ausgabe(ref messung);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ungültige Eingabe!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static Messung Eingabe()
        {
            Messung m;
            string bz;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte Bezeichnung eingeben");
                Console.Write(">>> ");
                bz = Console.ReadLine();
                Console.WriteLine();
                if(bz.Trim() == "")
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }
                    

                Console.WriteLine("Bitte Wert A (int) eingeben");
                Console.Write(">>> ");
                if(!Int32.TryParse(Console.ReadLine(), out int wertA))
                {
                    Console.WriteLine("\nUngültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine();

                Console.WriteLine("Bitte Wert B (double) eingeben");
                Console.Write(">>> ");
                if (!Double.TryParse(Console.ReadLine(), out double wertB))
                {
                    Console.WriteLine("\nUngültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine();

                m.bezeichnung = bz;
                m.wertA = wertA;
                m.wertB = wertB;
                m.datum = DateTime.Now;

                Console.Clear();
                Console.WriteLine("Eintrag hinzugefügt!");
                Console.ReadKey();
                return m;
            }
        }

        static void Ausgabe(ref List<Messung> lMessung)
        {
            Console.Clear();
            if(lMessung.Count == 0)
            {
                Console.WriteLine("Keine Einträge vorhanden!");
                Console.ReadKey();
                return;
            }
            int i = 1;
            foreach(Messung l in lMessung)
            {
                Console.WriteLine($"Messung Nr. {i}");
                Console.WriteLine($"Bezeichnung: {l.bezeichnung}");
                Console.WriteLine($"Wert A: {l.wertA}");
                Console.WriteLine($"Wert B: {l.wertB}");
                Console.WriteLine($"Datum: {l.datum:ddd. dd.MM.yyyy}"); //! Kurzschreibform von l.datum.ToString("ddd. dd.MM.yyyy")
                Console.WriteLine("---------------------------------------------\n\n");

                i++;
            }
            Console.ReadKey();
        }
    }
}
