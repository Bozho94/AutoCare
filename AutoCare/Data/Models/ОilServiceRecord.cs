using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AutoCare.EntityValidationConstants.ValidationConstants.OilServiceRecord;
namespace AutoCare.Data.Models
{
    // Unique index to ensure one-to-one relationship with Car
    [Index(nameof(CarId), IsUnique = true)]
    public class OilServiceRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.OilServiceRecord))]
        public Car Car { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете дата на смяна (масло и филтри)")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на смяна (масло и филтри)")]
        [Column(TypeName = "date")]
        public DateOnly OilChangeDate { get; set; }

        [Required(ErrorMessage = "Моля, въведете пробег при смяна (масло и филтри)")]
        [Range(0, int.MaxValue, ErrorMessage = "Километрите трябва да са неотрицателно число")]
        [Display(Name = "Пробег при смяна на масло и филтри (км)")]
        public int OdometerKm { get; set; }

        [Required(ErrorMessage = "Моля, въведете вискозитет на маслото (например 5W-40)")]
        [MaxLength(OilViscosityMaxLength, ErrorMessage = "Вискозитетът на маслото не може да надвишава 10 символа")]
        [Display(Name = "Вискозитет на маслото")]
        public string OilViscosity { get; set; } = null!;

        [MaxLength(OilAndFiltersBrandMaxLength)]
        [Display(Name = "Марка на маслото и филтрите (по желание)")]
        public string? OilAndFiltersBrand { get; set; }

        
    }
}
