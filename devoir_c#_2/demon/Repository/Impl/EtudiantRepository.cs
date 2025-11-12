using System;
using System.Collections.Generic;
using System.Linq;
using GesStud.Entity;

namespace GesStud.Repository.Impl
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly List<Etudiant> _etudiants = new List<Etudiant>();

        public void Add(Etudiant etudiant)
        {
            if (etudiant == null)
                throw new ArgumentNullException(nameof(etudiant));
            _etudiants.Add(etudiant);
        }

        public List<Etudiant> GetAll()
        {
            return _etudiants;
        }

        public Etudiant GetById(Guid id)
        {
            return _etudiants.FirstOrDefault(e => e.Id == id);
        }

        public bool Delete(Guid id)
        {
            var etu = GetById(id);
            if (etu == null)
                return false;

            _etudiants.Remove(etu);
            return true;
        }

        public void Update(Etudiant etudiant)
        {
            var existing = GetById(etudiant.Id);
            if (existing == null)
                return;

            existing.Nom = etudiant.Nom;
            existing.Prenom = etudiant.Prenom;
            existing.DateNaissance = etudiant.DateNaissance;
        }
    }
}
