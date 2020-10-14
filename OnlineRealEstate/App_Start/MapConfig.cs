using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
namespace OnlineRealEstate
{
    public class MapConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<PropertyModel, Property>();
                config.CreateMap<Property, PropertyModel>();
                config.CreateMap<PropertyFeatureModel, PropertyValues>();
                config.CreateMap<PropertyValues, PropertyFeatureModel>();
            }
            );
        }
    }
}