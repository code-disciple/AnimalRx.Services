using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRx.Services.Models
{

    public enum ReminderType
    { 
        Vaccine,
        Task,
        Inventory
    }

    [Table("reminder")]
    public class Reminder
    {
        public long ReminderId { get; set; }
        public DateTime? DueDate { get; set; }
        public ReminderType Type { get; set; }
    }
}
