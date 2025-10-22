using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class TechnicalInspectionVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime InspectionDate { get; set; }
    }
}
