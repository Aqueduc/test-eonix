using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public class Singe
    {
        public string Nom { get; set; } = "";

        public List<Tour> LsTours { get; private set; } = new List<Tour>()
        {
            new Tour("marcher sur les mains",EnumTour.ACROBATIQUE),
            new Tour("jongler avec des balles",EnumTour.ACROBATIQUE),
            new Tour("jouer de la trompette",EnumTour.MUSIQUE),
            new Tour("jouer du piano",EnumTour.MUSIQUE)
        };

        public Singe()
        {
            Nom = "Babouche";
        }

        public Singe(string nom)
        {
            Nom = nom;
        }

        public Tour FaitAction()
        {
            if (LsTours is null || LsTours.Count == 0)
                return new Tour();

            Random _random = new Random();
            var _randNext = _random.Next(LsTours.Count() - 1);
            var _tour = LsTours[_randNext];
            return _tour;
        }

        public Tour FaitAction(int index)
        {
            if (LsTours is null || LsTours.Count == 0)
                return new Tour();

            var _tour = LsTours[index];
            return _tour;
        }
    }
}
