using System;
using System.Collections.Generic;
using GesStud.Entity;

namespace GesStud.Repository
{
    public interface IEtudiantRepository
    {
        void Add(Etudiant etudiant);
        List<Etudiant> GetAll();
        Etudiant GetById(Guid id);
        bool Delete(Guid id);
        void Update(Etudiant etudiant);
    }
}
