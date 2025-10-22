using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class BeltServiceVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Required]
        public int OdometerKm { get; set; }

        public string? BeltsPumpBrand { get; set; }
    }
}
