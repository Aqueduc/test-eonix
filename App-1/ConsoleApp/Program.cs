using ConsoleApp.DataObject;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _spec1 = new Spectateur();
            var _dress1 = new Dresseur();
            var _dress2 = new Dresseur("Francois", "Pétoche");

            Console.WriteLine("Début du spectacle:");
            _dress1.ExecTours(_spec1);
            _dress2.ExecTours(_spec1);
            Console.WriteLine("Fin du spectacle");
        }
    }
}