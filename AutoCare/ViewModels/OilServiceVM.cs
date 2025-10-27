using System;
using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class OilServiceVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Изберете автомобил (CarId).")]
        [Display(Name = "Автомобил (CarId)")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Въведете дата на смяна (масло и филтри).")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на смяна (масло и филтри)")]
        public DateOnly OilChangeDate { get; set; }

        [Required(ErrorMessage = "Въведете пробег при смяната.")]
        [Range(0, int.MaxValue, ErrorMessage = "Пробегът трябва да е неотрицателен.")]
        [Display(Name = "Пробег (км)")]
        public int OdometerKm { get; set; }

        [Required(ErrorMessage = "Въведете вискозитет (напр. 5W-40).")]
        [Display(Name = "Вискозитет на маслото")]
        public string OilViscosity { get; set; } = null!;

        [Display(Name = "Марка на маслото и филтрите (по желание)")]
        public string? OilAndFiltersBrand { get; set; }
    }
}
