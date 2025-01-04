using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Required]
        public string nick { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string street { get; set; }
        public int? home_number { get; set; }
        [Required]
        public string city { get; set; }
        public string? state { get; set; }
        [Required]
        public string zipcode { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public bool is_active { get; set; } = false;
        [Required]
        public bool is_deleted { get; set; } = false;

        public User()
        {

        }
    }
}
