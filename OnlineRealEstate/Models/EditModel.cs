using System.Collections.Generic;

namespace OnlineRealEstate.Models
{
    public class EditModel
    {
        public PropertyModel PropertyModel { get; set; }
        public List<int> FeatureValues { get; set; }
        public List<string> PropertyFeatures { get; set; }

    }
}