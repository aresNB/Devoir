using System;
using System.Collections.Generic;
using System.Linq;
using GesStud.Entity;
using GesStud.Repository;

namespace GesStud.Services.Impl
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository _etudiantRepository;

        public EtudiantService(IEtudiantRepository etudiantRepository)
        {
            _etudiantRepository = etudiantRepository;
        }

        public void AjouterEtudiant(Etudiant etudiant)
        {
            _etudiantRepository.Add(etudiant);
        }

        public List<Etudiant> ListerEtudiants()
        {
            return _etudiantRepository.GetAll();
        }

        public Etudiant RechercherEtudiant(Guid id)
        {
            return _etudiantRepository.GetById(id);
        }

        public bool SupprimerEtudiant(Guid id)
        {
            return _etudiantRepository.Delete(id);
        }

        public void AjouterNote(Guid etudiantId, Note note)
        {
            var etu = _etudiantRepository.GetById(etudiantId);
            if (etu != null)
                etu.AjouterNote(note);
        }

        public List<Note> AfficherNotes(Guid etudiantId)
        {
            var etu = _etudiantRepository.GetById(etudiantId);
            return etu?.Notes ?? new List<Note>();
        }

        public Etudiant GetMeilleurEtudiant()
        {
            var etudiants = _etudiantRepository.GetAll();
            var avecMoyenne = etudiants
                .Where(e => e.CalculerMoyenne().HasValue)
                .OrderByDescending(e => e.CalculerMoyenne())
                .FirstOrDefault();

            return avecMoyenne;
        }

        public double? GetMoyenneClasse()
        {
            var etudiants = _etudiantRepository.GetAll();
            var moyennes = etudiants
                .Select(e => e.CalculerMoyenne())
                .Where(m => m.HasValue)
                .Select(m => m.Value)
                .ToList();

            if (!moyennes.Any())
                return null;

            return Math.Round(moyennes.Average(), 2);
        }
    }
}
