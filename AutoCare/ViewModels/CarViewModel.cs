using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Въведете марка")]
        [Display(Name = "Марка")]
        public string Brand { get; set; } = null!;
        [Required(ErrorMessage = "Въведете модел")]
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;
        [Required(ErrorMessage = "Въведете рег.номер")]
        [Display(Name = "Регистрационен номер")]
        public string RegistrationNumber { get; set; } = null!;
        [Required(ErrorMessage = "Въведете година на производство")]
        [Display(Name = "Година на производство")]
        public int YearOfManufacture { get; set; }
        public bool HasOilAndFilters { get; set; }
        public bool HasBeltsAndRollers { get; set; }
        public bool HasVignette { get; set; }
        public bool HasTechnicalInspection { get; set; }

    }
}
