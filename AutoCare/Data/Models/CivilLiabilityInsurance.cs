using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static AutoCare.EntityValidationConstants.ValidationConstants.CivilLiabilityInsurance;

namespace AutoCare.Data.Models
{
  
    public class CivilLiabilityInsurance
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.CivilLiabilityInsurances))]
        public Car Car { get; set; } = null!;

        [Required]
        [MaxLength(InsuranceCompanyNameMaxLength)]
        public string InsuranceCompanyName { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateOnly IssueDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly ExpiryDate { get; set; }
    }
}
