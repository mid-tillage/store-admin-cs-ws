using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_admin_cs_ws.Models
{
    [Table("fact_product_on_sale", Schema = "commerce")]
    public class ProductOnSale
    {
        [Key]
        [Column("id_product_on_sale")]
        public long IdProductOnSale { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [ForeignKey("Product")]
        [Column("id_product")]
        [Required]
        public long IdProduct { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("Catalog")]
        [Column("id_product_catalog")]
        public long IdProductCatalog { get; set; }
        public Catalog? Catalog { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("sale_start_datetime")]
        public DateTime SaleStartDatetime { get; set; }
        [Column("sale_end_datetime")]
        public DateTime SaleEndDatetime { get; set; }

        public ProductOnSale()
        {
            Title = "";
        }

        public ProductOnSale(long idProductOnSale, string title, Product product, Catalog catalog, decimal price, DateTime saleStartDatetime, DateTime saleEndDatetime)
        {
            IdProductOnSale = idProductOnSale;
            Title = title;
            Product = product;
            Catalog = catalog;
            Price = price;
            SaleStartDatetime = EnsureUtcDateTime(saleStartDatetime);
            SaleEndDatetime = EnsureUtcDateTime(saleEndDatetime);
        }

        private DateTime EnsureUtcDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                dateTime = dateTime.ToUniversalTime();
            }
            return dateTime;
        }
    }
}
