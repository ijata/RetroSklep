using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tax_id { get; set; }
        [Required]
        public char tax_name { get; set; }
        [Required]
        public int tax_value { get; set; }

        public Tax()
        {

        }
    }
}
