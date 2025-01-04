using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class StorehouseName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int storehouse_id { get; set; }
        [Required]
        public string name { get; set; }

        public StorehouseName()
        {

        }
    }
}
