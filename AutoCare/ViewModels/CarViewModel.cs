using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public string RegistrationNumber { get; set; } = null!;
        [Required]
        public int YearOfManufacture { get; set; }
        public bool HasOilAndFilters { get; set; }
        public bool HasBeltsAndRollers { get; set; }
        public bool HasVignette { get; set; }
        public bool HasTechnicalInspection { get; set; }

    }
}
