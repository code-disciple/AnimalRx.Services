using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.Models
{
    [Table("treatment")]
    public class Treatment
    {
        public long TreatmentId { get; set; }
        public long PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime? Date { get; set; }
        public string TreatmentAndDose { get; set; }
    }
}
