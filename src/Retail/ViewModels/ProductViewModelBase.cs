using System.ComponentModel.DataAnnotations;

namespace Retail.ViewModels
{
    public class ProductViewModelBase
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Label { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int UnitId { get; set; }

        public string Barcode { get; set; }

        public string Comments { get; set; }
    }
}
