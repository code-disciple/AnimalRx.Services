using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRx.Services.DataAccess;
using AnimalRx.Services.ViewModels;
using AnimalRx.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalRx.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     
    /// Controller for handling basic patient CRUD operations
    public class PatientController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;
        private IPatientRepository patientRepository;
        public PatientController(ILogger<PatientController> logger, IPatientRepository patientRepository)
        {
            _logger = logger;
            this.patientRepository = patientRepository;
        }

        //  /api/patients GET
        [HttpGet]
        public IEnumerable<PatientVM> Get()
        {
            var patients = patientRepository.GetPatients();
            List<PatientVM> patientsToBeReturned = new List<PatientVM>();
            foreach (var patient in patients)
            {
                var patientToBeReturned = new PatientVM() {
                    PatientId = patient.PatientId,
                    Name = patient.Name,
                    DateAdmitted = patient.DateAdmitted,
                    DateReleased = patient.DateReleased,
                    Description = patient.Description,
                    Diagnosis = patient.Diagnosis
                };

                var treatmentsToBeReturned = new List<TreatmentVM>();
                foreach (var treatment in patient.Treatments)
                {
                    var treatmentVM = new TreatmentVM()
                    {
                        TreatmentAndDose = treatment.TreatmentAndDose,
                        PatientId = treatment.PatientId,
                        Date = treatment.Date,
                        TreatmentId = treatment.TreatmentId
                    };

                    treatmentsToBeReturned.Add(treatmentVM);
                }

                var vaccinesToBeReturned = new List<VaccineVM>();
                foreach (var vaccine in patient.Vaccines)
                {
                    var vaccineVM = new VaccineVM() { 
                        VaccineId = vaccine.VaccineId,
                        PatientId = vaccine.PatientId,
                        Type = vaccine.Type.ToString(),
                        Dose1Delivered = vaccine.Dose1Delivered,
                        Dose1DeliveredDate = vaccine.Dose1DeliveredDate,
                        Dose1Required = vaccine.Dose1Required,
                        Dose1TargetDate = vaccine.Dose1TargetDate,
                        Dose2Delivered = vaccine.Dose2Delivered,
                        Dose2DeliveredDate = vaccine.Dose2DeliveredDate,
                        Dose2Required = vaccine.Dose2Required,
                        Dose2TargetDate = vaccine.Dose2TargetDate,
                        Dose3Delivered = vaccine.Dose3Delivered,
                        Dose3DeliveredDate = vaccine.Dose3DeliveredDate,
                        Dose3Required = vaccine.Dose3Required,
                        Dose3TargetDate = vaccine.Dose3TargetDate
                    };

                    vaccinesToBeReturned.Add(vaccineVM);
                }

                patientToBeReturned.Treatments = treatmentsToBeReturned;
                patientToBeReturned.Vaccines = vaccinesToBeReturned;
                patientsToBeReturned.Add(patientToBeReturned);
            }
            return patientsToBeReturned;
        }

        // /api/patients
        [HttpPost]
        public ActionResult<Patient> Post(Patient patient)
        {
            patientRepository.InsertPatient(patient);
            return CreatedAtAction("Get", new { id = patient.PatientId }, patient);
        }
    }
}
