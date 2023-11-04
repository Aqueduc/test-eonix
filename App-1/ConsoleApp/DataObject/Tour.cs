namespace ConsoleApp.DataObject
{
    public class Tour
    {
        public string Nom { get; set; } = "rien";
        public EnumTour? TypeTour { get; set; } = null;

        public Tour()
        {
            Nom = "rien";
            TypeTour = null;
        }

        public Tour(string nom, EnumTour typeTour)
        {
            Nom = nom;
            TypeTour = typeTour;
        }
    }
}