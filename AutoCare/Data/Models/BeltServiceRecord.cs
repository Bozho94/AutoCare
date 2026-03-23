using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AutoCare.EntityValidationConstants.ValidationConstants.BeltServiceRecord;
namespace AutoCare.Data.Models
{
  
    public class BeltServiceRecord 
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.BeltServiceRecords))]
        public Car Car { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateOnly ServiceDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int OdometerKm { get; set; }

        [MaxLength(BeltsPumpBrandMaxLength)]
        public string? BeltsPumpBrand { get; set; }

    }
}
