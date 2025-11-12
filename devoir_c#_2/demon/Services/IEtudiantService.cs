using System;
using System.Collections.Generic;
using GesStud.Entity;

namespace GesStud.Services
{
    public interface IEtudiantService
    {
        void AjouterEtudiant(Etudiant etudiant);
        List<Etudiant> ListerEtudiants();
        Etudiant RechercherEtudiant(Guid id);
        bool SupprimerEtudiant(Guid id);
        void AjouterNote(Guid etudiantId, Note note);
        List<Note> AfficherNotes(Guid etudiantId);
        Etudiant GetMeilleurEtudiant();
        double? GetMoyenneClasse();
    }
}
