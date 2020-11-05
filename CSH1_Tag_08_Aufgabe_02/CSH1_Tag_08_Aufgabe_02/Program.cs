using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_08_Aufgabe_02
{

    enum KYU
    {
        braun = 1,
        blau,
        grün,
        orange_grün,
        orange,
        gelb_orange,
        gelb,
        weiß_gelb,
        weiß
    }
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }


        static void KyuGrad()
        {
            char eingabe;
            Console.Clear();
            Console.Write("KyuGrad eingeben (9-1): ");
            eingabe = Console.ReadKey().KeyChar;

            if(Int32.TryParse(eingabe.ToString(), out int i) && Enum.IsDefined(typeof(KYU), i))
            {
                Console.WriteLine($"\nGürtelfarbe: {Enum.GetName(typeof(KYU), i)}");
            } else
            {
                Console.WriteLine("\nUngültige Eingabe!");
            }
            Console.ReadKey();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte auswählen");
                Console.WriteLine("1) Kyu-Grad");
                Console.WriteLine("2) Gürtel-Farbe");
                Console.WriteLine("3) Nächste Prüfung");
                Console.WriteLine("4) Beenden");
                Console.Write(">>> ");
                char c = Console.ReadKey().KeyChar;

                switch (c)
                {
                    case '1':
                        KyuGrad();
                        break;
                    case '2':
                        GuertelFarbe();
                        break;
                    case '3':
                        NaechstePruefung();
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("\nUngültige Eingabe!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GuertelFarbe()
        {
            short sh = GuertelFarbenAuswahlMenu();
            Console.Clear();
            Console.WriteLine($"Der Kyu-Grad ist: {sh}");
            Console.ReadKey();
        }

        static short GuertelFarbenAuswahlMenu()
        {
            short sh = (short)KYU.weiß;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mögliche Farben");
                foreach (KYU k in Enum.GetValues(typeof(KYU)))
                {
                    Console.WriteLine(Enum.GetName(typeof(KYU), k));
                }

                Console.Write("\nMit Pfeiltaste nach unten wählen: ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(Enum.GetName(typeof(KYU), sh));
                Console.ResetColor();
                ConsoleKey ck = Console.ReadKey().Key;

                if (ck == ConsoleKey.DownArrow && sh > 1)
                {
                    sh--;
                    continue;
                }
                else if (ck == ConsoleKey.DownArrow && sh == 1)
                {
                    sh = (short)KYU.weiß;
                    continue;
                }
                else if (ck == ConsoleKey.Enter)
                {
                    return sh;
                }
            }
        }

        static void NaechstePruefung()
        {
            short sh = GuertelFarbenAuswahlMenu();
            Console.Clear();
            Console.WriteLine($"Die Nächste Prüfung ist: {Enum.GetName(typeof(KYU), sh > (short)KYU.braun ? --sh : 1)}");
            Console.ReadKey();
        }
    }
}
