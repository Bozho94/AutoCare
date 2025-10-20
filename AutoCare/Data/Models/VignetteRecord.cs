using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCare.Data.Models
{
    // Unique index to ensure one-to-one relationship with Car
    [Index(nameof(CarId), IsUnique = true)]
    public class VignetteRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.VignetteRecord))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете дата на покупка")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на покупка")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на изтичане")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на изтичане")]
        public DateTime ExpiryDate { get; set; }


    }
}
