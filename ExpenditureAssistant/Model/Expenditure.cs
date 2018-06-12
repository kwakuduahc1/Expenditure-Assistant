using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenditureAssistant.Model
{
    public class Expenditure
    {
        [Key]
        public int ExpenditureID { get; set; }

        [Required, StringLength(100, MinimumLength = 5)]
        public string Item { get; set; }

        [Required]
        [ForeignKey("Cheques")]
        public int ChequesID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string PVNumber { get; set; }

        [Required]
        public int DepartmentsID { get; set; }

        public DateTime DateDone { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Cheques Cheques { get; set; }

        public virtual Departments Departments { get; set; }
    }
}
