using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRx.Services.Models;

namespace AnimalRx.Services.DataAccess
{
    public interface IPatientRepository
    {
        
        IEnumerable<Patient> GetPatients();

        // /api/patients
        Patient InsertPatient(Patient patient);

        IEnumerable<Vaccine> GetAllDueVaccines();
    }
}
