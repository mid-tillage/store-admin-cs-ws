using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_admin_cs_ws.Models
{
    [Table("dim_product", Schema = "commerce")]
    public class Product
    {
        [Key]
        [Column("id_product")]
        public long IdProduct { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [ForeignKey("Enterprise")]
        [Column("id_enterprise")]
        public long IdEnterprise { get; set; }
        public Enterprise Enterprise { get; set; }

        public Product()
        {
            Name = "";
            Description = "";
            Enterprise = new Enterprise();
        }

        public Product(long idProduct, string name, string description, Enterprise enterprise)
        {
            IdProduct = idProduct;
            Name = name;
            Description = description;
            Enterprise = enterprise;
        }
    }
}
