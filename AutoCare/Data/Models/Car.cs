using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AutoCare.EntityValidationConstants.ValidationConstants.Car;
namespace AutoCare.Data.Models
{
    // Unique index to ensure one-to-one relationship with User and unique RegistrationNumber per User
    [Index(nameof(UserId), nameof(RegistrationNumber), IsUnique = true)]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Липсва собственикът на автомобила")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете марка на автомобила")]
        [MaxLength(BrandMaxLength)]
        [Display(Name = "Марка на автомобила")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете модел на автомобила")]
        [MaxLength(ModelMaxLength)]
        [Display(Name = "Модел на автомобила")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете регистрационен номер на автомобила")]
        [MaxLength(RegistrationNumberMaxLength)]
        [Display(Name = "Регистрационен номер")]
        public string RegistrationNumber { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете година на производство")]
        [Range(YearOfManufactureMinValue, YearOfManufactureMaxValue, ErrorMessage = "Моля, въведете валидна година(пример: 2010)")]
        [Display(Name = "Година на производство")]
        public int YearOfManufacture { get; set; }

        [InverseProperty(nameof(OilServiceRecord.Car))]
        public OilServiceRecord? OilServiceRecord { get; set; }

        [InverseProperty(nameof(BeltServiceRecord.Car))]    
        public BeltServiceRecord? BeltServiceRecord { get; set; }

        [InverseProperty(nameof(VignetteRecord.Car))]
        public VignetteRecord? VignetteRecord { get; set; }

        [InverseProperty(nameof(TechnicalInspectionRecord.Car))]
        public TechnicalInspectionRecord? TechnicalInspectionRecord { get; set; }

        [InverseProperty(nameof(CivilLiabilityInsurance.Car))]
        public CivilLiabilityInsurance? CivilLiabilityInsurance { get; set; }


    }
}
