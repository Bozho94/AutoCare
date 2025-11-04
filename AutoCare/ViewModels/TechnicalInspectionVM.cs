using System;
using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class TechnicalInspectionVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Въведете дата на преглед.")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на преглед")]
        public DateOnly InspectionDate { get; set; }
    }
}
