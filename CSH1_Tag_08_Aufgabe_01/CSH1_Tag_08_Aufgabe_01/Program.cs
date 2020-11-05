using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_08_Aufgabe_01
{
    enum IHK
    {
        sehrGut = 92,
        gut = 81,
        befriedigend = 67,
        ausreichend = 50,
        mangelhaft = 30,
        ungenügend = 0
    }
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            while(true)
            {
                Console.Clear();
                Console.Write("Bitte Punktzahl eingeben ('!!!' zum beenden): ");
                eingabe = Console.ReadLine();
                
                if (eingabe == "!!!")
                    return;

                if(!Int32.TryParse(eingabe, out int i) || i < 0 || i > 100)
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    NoteErmitteln(i);
                }
            }
            
        }

        static void NoteErmitteln(int punkte)
        {
            Console.Clear();
            if (punkte >= (int)IHK.sehrGut)
                outNote(IHK.sehrGut);
            else if (punkte >= (int)IHK.gut)
                outNote(IHK.gut);
            else if (punkte >= (int)IHK.befriedigend)
                outNote(IHK.befriedigend);
            else if (punkte >= (int)IHK.ausreichend)
                outNote(IHK.ausreichend);
            else if (punkte >= (int)IHK.mangelhaft)
                outNote(IHK.mangelhaft);
            else
                outNote(IHK.ungenügend);

            Console.ReadKey();
        }

        static void outNote(IHK k)
        {
            Console.WriteLine($"Note lautet: {k}");
        }
    }
}
