using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OnlineRealEstate.Entity
{
    public class User
    {
        
         [Key]
         public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Index(IsUnique = true)] 
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string Role { get; set; }
        [Required]
        [MaxLength(20)]
        public string Location { get; set; }

    }
}
