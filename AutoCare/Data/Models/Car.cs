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



        // Navigation properties - One-to-Many relationships
        // Each Car can have multiple related records (oil services, belts, vignettes, inspections, insurances).
        // These collections reflect the one-to-many relationship design — each car can have
        // more than one record (for example, a current record and previous ones).
        // This supports the data model that allows "old records" to exist,
        // In the future, these collections may also be used for a "Car Details" page to display all related data for a car.
        [InverseProperty(nameof(OilServiceRecord.Car))]
        public ICollection<OilServiceRecord> OilServiceRecords { get; set; } = new List<OilServiceRecord>();

        [InverseProperty(nameof(BeltServiceRecord.Car))]
        public ICollection<BeltServiceRecord> BeltServiceRecords { get; set; } = new List<BeltServiceRecord>();

        [InverseProperty(nameof(VignetteRecord.Car))]
        public ICollection<VignetteRecord> VignetteRecords { get; set; } = new List<VignetteRecord>();

        [InverseProperty(nameof(TechnicalInspectionRecord.Car))]
        public ICollection<TechnicalInspectionRecord> TechnicalInspectionRecords { get; set; } = new List<TechnicalInspectionRecord>();

        [InverseProperty(nameof(CivilLiabilityInsurance.Car))]
        public ICollection<CivilLiabilityInsurance> CivilLiabilityInsurances { get; set; } = new List<CivilLiabilityInsurance>();



    }
}
