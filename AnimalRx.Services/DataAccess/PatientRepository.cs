using AnimalRx.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.DataAccess
{
    public class PatientRepository : IPatientRepository, IDisposable
    {
        AnimalRxContext context;
        public PatientRepository(AnimalRxContext dbContext) 
        {
            context = dbContext;
        }
        public IEnumerable<Patient> GetPatients()
        {
            return context.Patients.ToList(); ;
        }

        public Patient InsertPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Vaccine> GetAllDueVaccines()
        {
            return context.Vaccines.Where(v => v.Dose1Required == true && 
            v.Dose1TargetDate < DateTime.Today.AddDays(7)).ToList();
        }
    }
}
