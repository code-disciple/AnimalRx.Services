using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.Models
{
    [Table("patient")]
    public class Patient
    {
        public long PatientId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Diagnosis { get; set; }
        public DateTime? DateAdmitted { get; set; }

        public DateTime? DateReleased { get; set; }

        [ForeignKey("PatientId")]
        public virtual ICollection<Treatment> Treatments { get; set; }

        [ForeignKey("PatientId")]
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
