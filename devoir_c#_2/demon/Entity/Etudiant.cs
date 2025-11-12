using System;
using System.Collections.Generic;
using System.Linq;

namespace GesStud.Entity
{
    public class Etudiant
    {
        public Guid Id { get; private set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<Note> Notes { get; private set; } = new List<Note>();

        public Etudiant()
        {
            Id = Guid.NewGuid();
        }

        public Etudiant(string nom, string prenom, DateTime dateNaissance) : this()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }

        public void AjouterNote(Note note)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            if (note.Valeur < 0 || note.Valeur > 20)
                throw new ArgumentOutOfRangeException(nameof(note.Valeur), "La note doit être comprise entre 0 et 20.");

            Notes.Add(note);
        }

        public double? CalculerMoyenne()
        {
            if (!Notes.Any())
                return null;

            return Math.Round(Notes.Average(n => n.Valeur), 2);
        }

        public string ObtenirAppreciation()
        {
            double? moyenne = CalculerMoyenne();
            if (moyenne == null)
                return "Aucune note";

            if (moyenne >= 16) return "Très bien";
            if (moyenne >= 14) return "Bien";
            if (moyenne >= 12) return "Assez bien";
            if (moyenne >= 10) return "Passable";
            return "Insuffisant";
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom} - Moyenne: {CalculerMoyenne() ?? 0} ({ObtenirAppreciation()})";
        }
    }
}
