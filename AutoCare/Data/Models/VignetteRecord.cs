using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCare.Data.Models
{
    public class VignetteRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.VignetteRecords))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете начална дата на валидност")]
        [DataType(DataType.Date)]
        [Display(Name = "Начална дата на валидност")]
        [Column(TypeName = "date")]
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на изтичане")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на изтичане")]
        public DateOnly ExpiryDate { get; set; }


    }
}
