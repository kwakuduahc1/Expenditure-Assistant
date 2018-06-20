using System.ComponentModel.DataAnnotations;

namespace ExpenditureAssistant.Model
{
    public class SearchRanges
    {
        [Required]
        public int StartYear;

        [Required]
        public byte StartMonth;

        [Required]
        public int EndYear;

        [Required]
        public byte EndMonth;
    }
}
