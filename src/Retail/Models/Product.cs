using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Label")]
        public string Label { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("Barcode")]
        public string Barcode { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        [Column("Unit_Id")]
        public int UnitId { get; set; }

        [Column("UpdatedDate", TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        [Column("CreatedDate", TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
