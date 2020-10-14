using System.ComponentModel.DataAnnotations;
namespace OnlineRealEstate.Entity
{
    public class PropertyFeature
    {
        [Key]
        public int PropertyFeatureId { get; set; }
        public int PropertyTypeID { get; set; }
        public PropertyType PropertyType { get; set; }
        [Required]
        public string PropertyFeatureName { get; set; }
    }
}
