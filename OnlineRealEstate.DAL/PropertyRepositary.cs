using OnlineRealEstate.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineRealEstate.DAL
{
    public class PropertyRepositary
    {
        List<Property> propertyList = new List<Property>();
       
        public int Create(Property property)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                propertyContext.Property.Add(property);
                return propertyContext.SaveChanges();
            }
             
        }
        public IEnumerable<Property> DisplayPropertyDetails()
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                
                return propertyContext.Property.Include("PropertyType").ToList();
            }
        }
        public IEnumerable<PropertyValues> DisplayPropertyValueDetails()
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return propertyContext.PropertyValues.ToList();
            }
        }
        public IEnumerable<PropertyFeature> DisplayPropertyFeatureDetails()
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return propertyContext.PropertyFeatures.ToList();
            }
        }
        public Property Update(int landId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                Property property = new Property();
                property = propertyContext.Property.Find(landId);
                return property;
            }
        }
        public Dictionary<int,int> EditPropertyValues(int landId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                Dictionary<int, int> propertyValues = new Dictionary<int, int>();
                propertyValues=(from value in propertyContext.PropertyValues join property in propertyContext.Property on value.PropertyId equals property.PropertyId where value.PropertyId == landId select new { value.ValueId, value.Value }).ToDictionary(value=>value.ValueId,value=>value.Value);
                return propertyValues;
            }
        }
        public List<string> EditPropertyFeatures(int typeId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                List<string> propertyFeatures = new List<string>(); 
                propertyFeatures = (from feature in propertyContext.PropertyFeatures join property in propertyContext.PropertyType on feature.PropertyTypeID equals property.PropertyTypeID where feature.PropertyTypeID==typeId select feature.PropertyFeatureName).ToList();
                return propertyFeatures;
            }
        }
        public void UpdatePropertyDetails(Property property,Dictionary<int,int> propertyValues)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                propertyContext.Entry(property).State = EntityState.Modified;
                PropertyValues values = new PropertyValues();
                bool flag = true;
                List<int> propertyId = (from valuesObject in propertyContext.PropertyValues where property.PropertyId == valuesObject.PropertyId select valuesObject.PropertyId).ToList();
                int count=0;
                while(flag)
                { 
                    if (property.PropertyId==(propertyId[0]))
                    {
                        foreach (KeyValuePair<int, int> item in propertyValues)
                        {
                            values = (from valueObject in propertyContext.PropertyValues where valueObject.ValueId == item.Key select valueObject).Single();
                            values.Value = propertyValues[item.Key];
                            propertyContext.SaveChanges();
                        }
                        count++;
                    }
                    if(count==propertyValues.Count)
                    {
                        flag=false;
                    }
                }
                propertyContext.SaveChanges();

            }
        }
        public void Delete(int landId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {

                Property propertyvalue = propertyContext.Property.Find(landId);
                propertyContext.Property.Remove(propertyvalue);
                List<PropertyValues> propertyValues = (from value in propertyContext.PropertyValues where value.PropertyId == landId select value).ToList();
                for(int index=0;index<propertyValues.Count;index++)
                {
                    propertyContext.PropertyValues.Remove(propertyValues[index]);
                }
                propertyContext.SaveChanges();
            }

        }
        public IEnumerable<PropertyType> GetPropertyType()
        {
            using(PropertyContext propertyContext =new PropertyContext())
            {
                return propertyContext.PropertyType.ToList();
            }
        }
        public List<PropertyFeature> GetFeature(int typeId)
        {
            using(PropertyContext propertyContext=new PropertyContext())
            {

                PropertyFeature propertyFeatures = new PropertyFeature();
                return propertyContext.PropertyFeatures.Where(id => id.PropertyTypeID == typeId).ToList();
            }
        }
        public void AddPropertyValue(PropertyValues propertyValues,int []Value,int[] PropertyFeature)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                int index = 0;
                foreach(int value in Value)
                {
                    propertyValues.Value = value;
                    propertyValues.PropertyFeatureId = PropertyFeature[index];
                    index++;
                    propertyContext.PropertyValues.Add(propertyValues);
                    propertyContext.SaveChanges();
                }
                
            }
        }
        public IEnumerable<string> GetLocation()
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return (from property in propertyContext.Property select property.Location).ToList();
            }
        }
        public List<Property> SearchByLocation(string location,int typeId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return (from property in propertyContext.Property where property.Location == location && property.PropertyTypeID == typeId select property).Include("PropertyType").ToList();
            }
        }
        public List<PropertyValues> GetPropertyValueDetails(int propertyId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return (from propertyValue in propertyContext.PropertyValues where propertyValue.PropertyId == propertyId select propertyValue).ToList();
            }
        }
        public List<PropertyFeature> GetPropertyFeatureDetails(int propertyTypeId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return (from propertyFeature in propertyContext.PropertyFeatures where propertyFeature.PropertyTypeID == propertyTypeId select propertyFeature).ToList();
            }
        }

    }
}

