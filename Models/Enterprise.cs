using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_admin_cs_ws.Models
{
    [Table("dim_enterprise", Schema = "commerce")]
    public class Enterprise
    {
        [Key]
        [Column("id_enterprise")]
        public long IdEnterprise { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public Enterprise()
        {
            Name = "";
        }

        public Enterprise(long idEnterprise, string name)
        {
            IdEnterprise = idEnterprise;
            Name = name;
        }
    }
}
