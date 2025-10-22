using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class OilServiceVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime OilChangeDate { get; set; }

        [Required]
        public int OdometerKm { get; set; }

        [Required]
        public string OilViscosity { get; set; } = null!;

        public string? OilAndFiltersBrand { get; set; }
    }
}
