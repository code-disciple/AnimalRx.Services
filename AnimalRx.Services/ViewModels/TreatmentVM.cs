using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.ViewModels
{
    public class TreatmentVM
    {
        public long TreatmentId { get; set; }
        public long PatientId { get; set; }
        public DateTime? Date { get; set; }
        public string TreatmentAndDose { get; set; }
    }
}
