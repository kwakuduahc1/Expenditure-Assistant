using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class ExpenditureItems
    {
        public int ExpenditureItemsID { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
