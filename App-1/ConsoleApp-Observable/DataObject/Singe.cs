using ConsoleApp.DataObject.Observable;
using ConsoleApp.DataObject.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public class Singe : ISubject
    {

        public List<IObserver> LsObservers { get; set; } = new List<IObserver>();
        public List<Tour> LsAction { get; private set; } = new List<Tour>()
        {
            new TourAcrobatie(){Nom = "marche sur les mains"},
            new TourAcrobatie(){Nom = "jongle avec des balles"},
            new TourAcrobatie(){Nom = "fait une pirouette"},
            new TourMusique(){Nom = "joue du saxophone"},
            new TourMusique(){Nom = "joue de la contrebasse"},
            new TourMusique(){Nom = "fait du tamtam"}
        };


        public string Nom { get; set; } = "";

        public Singe()
        {
            Nom = "babouche";
        }
        public Singe(string nom)
        {
            Nom = nom;
        }

        public string FaitAction()
        {
            Random _rand = new Random();
            var _nextRand = _rand.Next(LsAction.Count - 1);
            var _action = LsAction[_nextRand];
            Console.WriteLine(string.Format("{0} {1}",Nom,_action.Nom));
            Notify(_action,this);
            return _action.Nom;
        }

        public void Attach(IObserver obs)
        {
            if (LsObservers.Contains(obs))
                return;

            LsObservers.Add(obs);
        }

        public void Detach(IObserver obs)
        {
            if (!LsObservers.Contains(obs))
                return;

            LsObservers.Remove(obs);
        }

        public void Notify(Tour tour,ISubject singe)
        {
            if (LsObservers.Count > 0)
                LsObservers.ForEach(obs =>
                {
                    obs.Update(tour,singe);
                });
        }

    }
}
