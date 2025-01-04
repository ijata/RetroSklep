using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int author_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }

        public Author()
        {

        }
    }
}
