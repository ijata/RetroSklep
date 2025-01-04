using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class UserTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int type_id { get; set; }
        [Required]
        public string name { get; set; }


        public UserTypes()
        {

        }
    }
}
