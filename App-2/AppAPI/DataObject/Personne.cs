namespace AppAPI.DataObject
{
    public class Personne
    {
        public Guid Id { get; set; }
        public string Prenom { get; set; } = "";
        public string Nom { get; set; } = "";

        public Personne(string prenom, string nom)
        {
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
                throw new Exception("Le nom/prenom ne peut pas être vide");

            Id = new Guid();
            Prenom = prenom;
            Nom = nom;
        }

        public bool IsMatch(string? prenom, string? nom)
        {
            if (prenom is null)
                prenom = "";
            if (nom is null)
                nom = "";

            return
                (!string.IsNullOrEmpty(prenom) && Prenom.StartsWith(prenom, StringComparison.CurrentCultureIgnoreCase))
                ||
                (!string.IsNullOrEmpty(prenom) && Prenom.EndsWith(prenom, StringComparison.CurrentCultureIgnoreCase))
                ||
                (!string.IsNullOrEmpty(nom) && Nom.StartsWith(nom, StringComparison.CurrentCultureIgnoreCase))
                ||
                (!string.IsNullOrEmpty(nom) && Nom.EndsWith(nom, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
