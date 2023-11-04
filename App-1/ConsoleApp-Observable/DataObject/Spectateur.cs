using ConsoleApp.DataObject.Observable;
using ConsoleApp.DataObject.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public class Spectateur : IActionSpectateur, IObserver
    {
        public string Nom { get; set; }

        public Spectateur()
        {
            Nom = "Inconnu";
        }
        public Spectateur(string nom)
        {
            Nom = nom;
        }
        public string Applaudir(Singe singe)
        {
            return string.Format("{0} applaudit au singe {1}", Nom, singe.Nom);
        }

        public string Siffler(Singe singe)
        {
            return string.Format("{0} siffle au singe {1}", Nom, singe.Nom);
        }

        public void Update(Tour tour, ISubject singe)
        {
            var _singe = singe as Singe;
            if (_singe is null)
                return;

            switch (tour)
            {
                case TourAcrobatie:
                    Console.WriteLine(Applaudir(_singe));
                    break;
                case TourMusique:
                    Console.WriteLine(Siffler(_singe));
                    break;
                default:
                    Console.WriteLine("Je ne sais pas ce que ce singe est en train de faire...");
                    break;
            }


        }
    }
}
