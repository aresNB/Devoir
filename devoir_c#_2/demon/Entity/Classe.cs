using System;
using System.Collections.Generic;
using System.Linq;

namespace GesStud.Entity
{
    public class Classe
    {
        public string Libelle { get; set; }        // Exemple : "Terminale A"
        public List<Etudiant> Etudiants { get; private set; } = new List<Etudiant>();

        public Classe() { }

        public Classe(string libelle)
        {
            Libelle = libelle;
        }

        public void AjouterEtudiant(Etudiant etudiant)
        {
            if (etudiant == null)
                throw new ArgumentNullException(nameof(etudiant));

            Etudiants.Add(etudiant);
        }

        public bool SupprimerEtudiant(Guid id)
        {
            var etu = Etudiants.FirstOrDefault(e => e.Id == id);
            if (etu == null)
                return false;

            Etudiants.Remove(etu);
            return true;
        }

        public double? CalculerMoyenneClasse()
        {
            var moyennes = Etudiants
                .Select(e => e.CalculerMoyenne())
                .Where(m => m.HasValue)
                .Select(m => m.Value)
                .ToList();

            if (!moyennes.Any())
                return null;

            return Math.Round(moyennes.Average(), 2);
        }

        public List<Etudiant> GetMeilleursEtudiants()
        {
            var avecMoyennes = Etudiants
                .Select(e => new { Etu = e, Moy = e.CalculerMoyenne() })
                .Where(x => x.Moy.HasValue)
                .ToList();

            if (!avecMoyennes.Any())
                return new List<Etudiant>();

            var max = avecMoyennes.Max(x => x.Moy.Value);
            return avecMoyennes
                .Where(x => Math.Abs(x.Moy.Value - max) < 0.0001)
                .Select(x => x.Etu)
                .ToList();
        }

        public override string ToString()
        {
            return $"{Libelle} - {Etudiants.Count} étudiants";
        }
    }
}
