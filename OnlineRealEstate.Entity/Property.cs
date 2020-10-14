using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace OnlineRealEstate.Entity
{
    public class Property
    {
        
        [Key]
            public int PropertyId { get; set; }
            public int PropertyTypeID { get; set; }
        public int UserId { get; set; } 

        public  PropertyType PropertyType { get; set; }
        [Required]
            public string Location { get; set; }
        [Required]
            public int Price { get; set; }
        [Required]
        public int Area { get; set; }
        public byte[] Image { get; set; }
    }
   
}
