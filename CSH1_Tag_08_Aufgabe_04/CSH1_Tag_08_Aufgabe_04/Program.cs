using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_08_Aufgabe_04
{
    class Program
    {
        #region ENUM
        enum Sonderfall
        {
            personExistiertNicht = -2,
            personHatKeinAuto
        }
        #endregion

        #region STRUCTS
        struct Person
        {
            public int id;
            public string vorname, nachname;
        }

        struct Auto
        {
            public string marke, kennzeichen;
            public int baujahr;
            public Person person;
        }
        #endregion

        static int id = 1;
        static void Main(string[] args)
        {
            //Person ID 1
            PersonAbfüllen(out Person p1, "Hans", "Müller");
            FuelleAuto(out Auto a1, "Renault", "W-TE-21", 1975, p1);
            FuelleAuto(out Auto a2, "Skoda", "W-LK-1937", 2015, p1);

            //Person ID 2
            PersonAbfüllen(out Person p2, "Klaus", "Schmidt");
            FuelleAuto(out Auto a3, "Volkswagen", "W-PA-1966", 2000, p2);

            //Person ID 3
            PersonAbfüllen(out Person p3, "Peter", "Mayer");

            List<Person> pListe = new List<Person>
            {
                p1,
                p2,
                p3
            };

            List<Auto> aListe = new List<Auto>
            {
                a1,
                a2,
                a3
            };

            int rVal;
            for(int i = 0; i <= 3; i++)
            {
                rVal = ZeigeAeltestesAutoVonPerson(pListe, aListe, i);
                switch (rVal)
                {
                    case (int)Sonderfall.personExistiertNicht:
                        Console.WriteLine($"ID {i} - Person existiert nicht!");
                        break;
                    case (int)Sonderfall.personHatKeinAuto:
                        Console.WriteLine($"ID {i} - Person hat kein Auto!");
                        break;
                    default:
                        Console.WriteLine($"ID {i} - Ältestes Auto ist von Baujahr {rVal}");
                        break;
                }
            }
            Console.ReadKey();
        }

        static void PersonAbfüllen(out Person p, string vorname, string nachname)
        {
            p.id = id++;
            p.vorname = vorname;
            p.nachname = nachname;
        }

        static void FuelleAuto(out Auto a, string marke, string kennzeichen, int baujahr, Person besitzer)
        {
            a.marke = marke;
            a.kennzeichen = kennzeichen;
            a.baujahr = baujahr;
            a.person = besitzer;
        }

        static int ZeigeAeltestesAutoVonPerson(List<Person> pListe, List<Auto> aListe, int x)
        {
            if(!pListe.Any(p => p.id == x))
            {
                return (int)Sonderfall.personExistiertNicht;
            }
            else if(aListe.Any(a => a.person.id == x))
            {
                return aListe.FindAll(a => a.person.id == x).Min(a => a.baujahr);
            }

            return (int)Sonderfall.personHatKeinAuto;
        }
    }
}
