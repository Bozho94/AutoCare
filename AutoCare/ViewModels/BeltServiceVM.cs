using System;
using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class BeltServiceVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Въведете дата на смяната.")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на смяна (ремъци и водна помпа)")]
        public DateOnly ServiceDate { get; set; }

        [Required(ErrorMessage = "Въведете пробег при смяната.")]
        [Range(0, int.MaxValue, ErrorMessage = "Пробегът трябва да е неотрицателен.")]
        [Display(Name = "Пробег (км)")]
        public int OdometerKm { get; set; }

        [Display(Name = "Марка на ремъци и водна помпа (по желание)")]
        public string? BeltsPumpBrand { get; set; }
    }
}
