using System;

namespace GesStud.Entity
{
    public class Note
    {
        public string Matiere { get; set; }
        public double Valeur { get; set; }
        public DateTime DateAttribution { get; set; }

        public Note()
        {
            DateAttribution = DateTime.Now;
        }

        public Note(string matiere, double valeur, DateTime? dateAttribution = null)
        {
            if (valeur < 0 || valeur > 20)
                throw new ArgumentOutOfRangeException(nameof(valeur), "La note doit être comprise entre 0 et 20.");

            Matiere = matiere;
            Valeur = valeur;
            DateAttribution = dateAttribution ?? DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Matiere}: {Valeur}/20 (attribuée le {DateAttribution:dd/MM/yyyy})";
        }
    }
}
