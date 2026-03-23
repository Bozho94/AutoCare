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
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(RegistrationNumberMaxLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [Range(YearOfManufactureMinValue, YearOfManufactureMaxValue)]
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
