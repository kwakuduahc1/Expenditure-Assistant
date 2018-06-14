using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class Cheques
    {
        [Key]
        public int ChequesID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ChequeNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime DateIssued { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
