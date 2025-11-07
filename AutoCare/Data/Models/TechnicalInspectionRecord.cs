using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCare.Data.Models
{
    public class TechnicalInspectionRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.TechnicalInspectionRecords))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете дата на прегледа")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на прегледа")]
        [Column(TypeName = "date")]
        public DateOnly InspectionDate { get; set; }
    }
}

