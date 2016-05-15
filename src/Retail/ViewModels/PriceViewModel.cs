using System;
using System.ComponentModel.DataAnnotations;

namespace Retail.ViewModels
{
    public class PriceViewModel
    {
        public int Id { get; set; }

        public bool Bogo { get; set; }

        public bool Sale { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
