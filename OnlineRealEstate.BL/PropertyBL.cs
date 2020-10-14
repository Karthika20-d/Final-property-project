using OnlineRealEstate.DAL;
using OnlineRealEstate;
using OnlineRealEstate.Entity;
using System.Collections.Generic;

namespace OnlineRealEstate.BL
{
    public class PropertyBL
    {
        PropertyRepositary propertyRepositary = new PropertyRepositary();
        public int Create(Property property)
        {
            return propertyRepositary.Create(property);
        }
        public IEnumerable<Property> DisplayPropertyDetails()
        {
            return propertyRepositary.DisplayPropertyDetails();
        }
        public IEnumerable<PropertyValues> DisplayPropertyValueDetails()
        {
            return propertyRepositary.DisplayPropertyValueDetails();
        }
        public IEnumerable<PropertyFeature> DisplayPropertyFeatureDetails()
        {
            return propertyRepositary.DisplayPropertyFeatureDetails();
        }
        public Property Update(int landId)
        {
           return propertyRepositary.Update(landId);
        }
        public Dictionary<int,int> EditPropertyValues(int landId)
        {
            return propertyRepositary.EditPropertyValues(landId);
        }
        public List<string> EditPropertyFeatures(int typeId)
        {
            return propertyRepositary.EditPropertyFeatures(typeId);
        }
        public void UpdatePropertyDetails(Property property,Dictionary<int,int> propertyValues)
        {
            propertyRepositary.UpdatePropertyDetails(property,propertyValues);
        }
        public void Delete(int landId)
        {
            propertyRepositary.Delete(landId);
        }
        public IEnumerable<PropertyType> GetPropertyType()
        {
            return propertyRepositary.GetPropertyType();
        }
        public List<PropertyFeature> GetFeature(int typeId)
        {
            return propertyRepositary.GetFeature(typeId);
        }
        public void AddPropertyValue(PropertyValues propertyValues,int []Value,int [] PropertyFeatureId)
        {
            propertyRepositary.AddPropertyValue(propertyValues,Value, PropertyFeatureId);
        }
        public IEnumerable<string> GetLocation()
        {
            return propertyRepositary.GetLocation();
        }
        public List<Property> SearchByLocation(string location,int typeId)
        {
            return propertyRepositary.SearchByLocation(location, typeId);
        }
        public List<PropertyValues> GetPropertyValueDetails(int propertyId)
        {
            return propertyRepositary.GetPropertyValueDetails(propertyId);
        }
        public List<PropertyFeature> GetPropertyFeatureDetails(int propertyTypeId)
        {
            return propertyRepositary.GetPropertyFeatureDetails(propertyTypeId);
        }
    }
}
