using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authantcate_Core.Models
{
    public class user_tbl
    {
        [Key]
        [DisplayName("Student Id")]
        [Column("Student Id")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Student Name")]
        [Column("Student Name")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? Stanterd { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
