using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AutoCare.EntityValidationConstants.ValidationConstants.OilServiceRecord;
namespace AutoCare.Data.Models
{
    public class OilServiceRecord
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.OilServiceRecords))]
        public Car Car { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateOnly OilChangeDate { get; set; }

        [Required]
        [Range(0, int.MaxValue]
        public int OdometerKm { get; set; }

        [Required]
        [MaxLength(OilViscosityMaxLength]
        public string OilViscosity { get; set; } = null!;

        [MaxLength(OilAndFiltersBrandMaxLength)]
        public string? OilAndFiltersBrand { get; set; }

        
    }
}
