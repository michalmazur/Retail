using System.ComponentModel.DataAnnotations;

namespace Retail.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Label { get; set; }
    }
}
