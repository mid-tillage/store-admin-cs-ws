using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_admin_cs_ws.Models
{
    [Table("dim_product_catalog", Schema = "commerce")]
    public class Catalog
    {
        [Key]
        [Column("id_product_catalog")]
        public long IdProductCatalog { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public Catalog()
        {
            Name = "";
        }

        public Catalog(long idProductCatalog, string name)
        {
            IdProductCatalog = idProductCatalog;
            Name = name;
        }
    }
}
