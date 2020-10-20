using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRealEstate.Entity
{
    public class BuyerProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public int PropertyTypeID { get; set; }
        public int UserId { get; set; }

        public PropertyType PropertyType { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Area { get; set; }
        public byte[] Image { get; set; }
        public string Status { get; set; }
    }
}
