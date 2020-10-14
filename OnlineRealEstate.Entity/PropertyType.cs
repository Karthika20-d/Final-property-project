
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRealEstate.Entity
{
    public class PropertyType
    {
        [Key]
        public  int PropertyTypeID { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
