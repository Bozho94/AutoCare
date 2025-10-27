using System;
using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class VignetteVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Изберете автомобил (CarId).")]
        [Display(Name = "Автомобил (CarId)")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Въведете дата на покупка.")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на покупка")]
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessage = "Въведете дата на изтичане.")]
        [DataType(DataType.Date)]
        [Display(Name = "Валидна до")]
        public DateOnly ExpiryDate { get; set; }
    }
}
