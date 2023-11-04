using ConsoleApp.DataObject;
using ConsoleApp.DataObject.Observable;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _gradins = new List<IObserver>() { };
            var _spec = new Spectateur();
            _gradins.Add(_spec);


            var _dres1 = new Dresseur("Polo", "Marco", "Petoche");
            var _dres2 = new Dresseur("Jean", "Jean", "Jean-Jean");


            Console.WriteLine("Début du spectacle :");

            _dres1.ExecTours(_gradins);
            _dres2.ExecTours(_gradins);

            Console.ReadLine();
        }
    }
}