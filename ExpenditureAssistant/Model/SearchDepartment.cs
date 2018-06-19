using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class SearchDepartment
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int Fetch { get; set; }

        [Required]
        public int Offset { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public byte Month { get; set; }

        [Required]
        public int EndYear { get; set; }

        [Required]
        public byte EndMonth { get; set; }
    }
}
