using System;
using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class VignetteVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Моля, въведете начална дата на валидност")]
        [DataType(DataType.Date)]
        [Display(Name = "Начална дата на валидност")]
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessage = "Въведете дата на изтичане.")]
        [DataType(DataType.Date)]
        [Display(Name = "Валидна до")]
        public DateOnly ExpiryDate { get; set; }
    }
}
