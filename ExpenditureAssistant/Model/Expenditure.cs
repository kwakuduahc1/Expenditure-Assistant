using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class Expenditure
    {
        [Key]
        public int ExpenditureID { get; set; }

        [Required, StringLength(100, MinimumLength = 5)]
        public string Item { get; set; }

        [Required]
        public int ChequesID { get; set; }

        [Range(0.1,double.MaxValue)]
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string PVNumber { get; set; }

        [Required]
        public int DepartmentsID { get; set; }

        [Required]
        public int ExpenditureItemsID { get; set; }

        public DateTime DateDone { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Cheques Cheques { get; set; }

        public virtual Departments Departments { get; set; }

        public virtual ExpenditureItems ExpenditureItems { get; set; }
    }
}
