using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Models
{
    [Table("Prices")]
    public class Price
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Bogo")]
        public bool Bogo { get; set; }

        [Column("Sale")]
        public bool Sale { get; set; }

        [Column("UpdatedDate", TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        [Column("CreatedDate", TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column("Store_Id")]
        public int StoreId { get; set; }

        [Column("Product_id")]
        public int ProductId { get; set; }

        [Column("PurchasePrice")]
        public decimal Cost { get; set; }
    }
}
