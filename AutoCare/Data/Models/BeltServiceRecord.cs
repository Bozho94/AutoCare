using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AutoCare.EntityValidationConstants.ValidationConstants.BeltServiceRecord;
namespace AutoCare.Data.Models
{
    // Unique index to ensure one-to-one relationship with Car
    [Index(nameof(CarId), IsUnique = true)]
    public class BeltServiceRecord 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.BeltServiceRecord))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете дата на смяна (ремъци и водна помпа)")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на смяна (ремъци и водна помпа)")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Моля, въведете пробег при смяна (ремъци и водна помпа)")]
        [Range(0, int.MaxValue, ErrorMessage = "Километрите трябва да са неотрицателно число")]
        [Display(Name = "Пробег при смяна (ремъци и водна помпа) (км)")]
        public int OdometerKm { get; set; }

        [MaxLength(BeltsPumpBrandMaxLength)]
        [Display(Name = "Марка на ремъци и водна помпа (по желание)")]
        public string? BeltsPumpBrand { get; set; }

    }
}
