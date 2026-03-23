using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCare.Data.Models
{
    public class VignetteRecord
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.VignetteRecords))]
        public Car Car { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateOnly PurchaseDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly ExpiryDate { get; set; }


    }
}
