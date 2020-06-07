using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.ViewModels
{
    public class VaccineVM
    {
        public long VaccineId { get; set; }
        public long PatientId { get; set; }
        public string Type { get; set; }
        public DateTime? Dose1TargetDate { get; set; }
        public DateTime? Dose2TargetDate { get; set; }
        public DateTime? Dose3TargetDate { get; set; }
        public DateTime? Dose1DeliveredDate { get; set; }
        public DateTime? Dose2DeliveredDate { get; set; }
        public DateTime? Dose3DeliveredDate { get; set; }
        public bool Dose1Delivered { get; set; }
        public bool Dose1Required { get; set; }
        public bool Dose2Delivered { get; set; }
        public bool Dose2Required { get; set; }
        public bool Dose3Delivered { get; set; }
        public bool Dose3Required { get; set; }
    }
}
