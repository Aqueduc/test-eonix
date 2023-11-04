using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public class Spectateur
    {
        public string Nom { get; set; } = "Spectateur";

        public string ReactTour(Tour tour)
        {
            if (tour is null || tour.TypeTour is null)
                throw new ArgumentNullException("Le tour est reconnu comme null");

            var _tmp = "";
            switch (tour.TypeTour)
            {
                case EnumTour.ACROBATIQUE:
                    _tmp = "applaudit pendant le tour d'acrobatie";
                    break;
                case EnumTour.MUSIQUE:
                    _tmp = "siffle pendant le tour de musique";
                    break;
                default:
                    _tmp = "reste de marbre";
                    break;
            }

            return _tmp;
        }
    }
}
