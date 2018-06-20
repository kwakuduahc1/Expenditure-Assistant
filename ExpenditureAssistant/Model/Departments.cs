using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class Departments
    {
        [Key]
        public int DepartmentsID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Department { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Expenditure> Expenditure { get; set; }
    }
}
