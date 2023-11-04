using ConsoleApp.DataObject.Observable;
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
        public string Prenom { get; set; } = "";

        public Singe Singe { get; set; } = new Singe();

        public Dresseur(string nom, string prenom, string nomSinge)
        {
            Nom = nom;
            Prenom = prenom;
            Singe.Nom = nomSinge;
        }

        public void ExecTours(List<IObserver> observers)
        {
            if (observers.Count == 0)
                return;

            Singe.LsObservers = observers;
            for (int i = 0; i < Singe.LsAction.Count; i++)
            {
                Singe.FaitAction();
                Thread.Sleep(2000);
            }
        }
    }
}
