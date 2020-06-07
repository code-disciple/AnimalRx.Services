using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.ViewModels
{
    public class PatientVM
    {
        public long PatientId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Diagnosis { get; set; }
        public DateTime? DateAdmitted { get; set; }

        public DateTime? DateReleased { get; set; }

        public ICollection<TreatmentVM> Treatments { get; set; }

        public ICollection<VaccineVM> Vaccines { get; set; }
    }
}
