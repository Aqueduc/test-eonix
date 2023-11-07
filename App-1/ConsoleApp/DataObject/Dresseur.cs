using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public class Dresseur
    {
        public string Nom { get; set; } = "";
        private Singe Singe { get; set; } = new Singe();

        public Dresseur()
        {
            Nom = "Dora";
            Singe = new Singe();
        }

        public Dresseur(string nom, string nomSinge)
        {
            Nom = nom;
            Singe = new Singe(nomSinge);
        }

        public void ExecTours(Spectateur spectateur)
        {
            if (spectateur is null)
                return;

            for (int i = 0; i < Singe.LsTours.Count; i++)
            {
                var _tour = Singe.FaitAction(i);
                //var _tour = Singe.FaitAction();
                var _reaction = spectateur.ReactTour(_tour);
                Console.WriteLine(string.Format("{0} {1} '{2}' du singe {3}", spectateur.Nom, _reaction, _tour.Nom, Singe.Nom));
                Thread.Sleep(2000);
            }
        }


    }
}
