using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineRealEstate.Entity
{
    public class PropertyValues
    {
        [Key]
        public int ValueId { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int PropertyFeatureId { get; set; }
        public PropertyFeature PropertyFeatures { get; set; }
        [Required]
        public int Value { get; set; }

    }
}
