using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static AutoCare.EntityValidationConstants.ValidationConstants.CivilLiabilityInsurance;

namespace AutoCare.Data.Models
{
  
    public class CivilLiabilityInsurance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.CivilLiabilityInsurance))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете име на застраховател")]
        [MaxLength(InsuranceCompanyNameMaxLength, ErrorMessage = "Името не може да бъде повече от 50 символа.")]
        [Display(Name = "Застрахователна компания")]
        public string InsuranceCompanyName { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете начална дата на валидност")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на издаване")]
        [Column(TypeName = "date")]
        public DateOnly IssueDate { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на изтичане")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на изтичане")]
        public DateOnly ExpiryDate { get; set; }
    }
}
