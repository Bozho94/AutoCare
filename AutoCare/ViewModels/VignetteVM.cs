using System.ComponentModel.DataAnnotations;

namespace AutoCare.ViewModels
{
    public class VignetteVM
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
