using System;
using System.Collections.Generic;
using GesStud.Entity;
using GesStud.Services;

namespace GesStud.View
{
    public class ConsoleView
    {
        private readonly IEtudiantService _etudiantService;

        public ConsoleView(IEtudiantService etudiantService)
        {
            _etudiantService = etudiantService;
        }

        public void AfficherMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- GESTION DES ETUDIANTS ---");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Lister les étudiants");
                Console.WriteLine("3. Ajouter une note");
                Console.WriteLine("4. Afficher les notes d'un étudiant");
                Console.WriteLine("5. Afficher le meilleur étudiant");
                Console.WriteLine("6. Afficher la moyenne de la classe");
                Console.WriteLine("0. Quitter");
                Console.Write("Choix : ");

                var choix = Console.ReadLine();
                switch (choix)
                {
                    case "1": AjouterEtudiant(); break;
                    case "2": ListerEtudiants(); break;
                    case "3": AjouterNote(); break;
                    case "4": AfficherNotes(); break;
                    case "5": AfficherMeilleurEtudiant(); break;
                    case "6": AfficherMoyenneClasse(); break;
                    case "0": return;
                    default: Console.WriteLine("Choix invalide."); break;
                }
            }
        }

        private void AjouterEtudiant()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Date de naissance (yyyy-MM-dd) : ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine()!);

            var etudiant = new Etudiant(nom, prenom, dateNaissance);
            _etudiantService.AjouterEtudiant(etudiant);
            Console.WriteLine("Étudiant ajouté !");
        }

        private void ListerEtudiants()
        {
            var etudiants = _etudiantService.ListerEtudiants();
            foreach (var e in etudiants)
            {
                Console.WriteLine(e);
            }
        }

        private void AjouterNote()
        {
            Console.Write("ID de l'étudiant : ");
            Guid id = Guid.Parse(Console.ReadLine()!);

            Console.Write("Matière : ");
            string matiere = Console.ReadLine()!;
            Console.Write("Valeur de la note : ");
            double valeur = double.Parse(Console.ReadLine()!);

            var note = new Note(matiere, valeur);
            _etudiantService.AjouterNote(id, note);
            Console.WriteLine("Note ajoutée !");
        }

        private void AfficherNotes()
        {
            Console.Write("ID de l'étudiant : ");
            Guid id = Guid.Parse(Console.ReadLine()!);

            var notes = _etudiantService.AfficherNotes(id);
            if (notes.Count == 0)
            {
                Console.WriteLine("Aucune note trouvée.");
                return;
            }

            foreach (var n in notes)
                Console.WriteLine(n);
        }

        private void AfficherMeilleurEtudiant()
        {
            var e = _etudiantService.GetMeilleurEtudiant();
            if (e == null)
                Console.WriteLine("Aucun étudiant avec des notes.");
            else
                Console.WriteLine($"Meilleur étudiant : {e}");
        }

        private void AfficherMoyenneClasse()
        {
            var moyenne = _etudiantService.GetMoyenneClasse();
            if (moyenne == null)
                Console.WriteLine("Aucune note dans la classe.");
            else
                Console.WriteLine($"Moyenne de la classe : {moyenne}");
        }
    }
}
