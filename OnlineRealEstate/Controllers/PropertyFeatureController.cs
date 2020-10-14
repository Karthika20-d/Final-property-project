using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineRealEstate.Controllers
{
    public class PropertyFeatureController : Controller
    {
        // GET: PropertyFeature
        PropertyBL propertyBL = new PropertyBL();
        public ActionResult AddFeature()
        {
            Property property = TempData["TypeId"] as Property;
            List<PropertyFeature> propertyFeatures = propertyBL.GetFeature(property.PropertyTypeID);
            //ArrayList featureId = new ArrayList();
            PropertyFeatureModel model = new PropertyFeatureModel();
            ViewBag.propertyFeature = propertyFeatures;
            model.PropertyId = property.PropertyId;
            return this.View(model);
        }
        // [HttpPost]
        public ActionResult AddPropertyValue(PropertyFeatureModel propertyFeature, int[] Value, int[] PropertyFeatureId)
        {
            PropertyValues propertyValues = new PropertyValues();
            propertyValues = AutoMapper.Mapper.Map<PropertyFeatureModel, PropertyValues>(propertyFeature);
            propertyBL.AddPropertyValue(propertyValues, Value, PropertyFeatureId);
            return RedirectToAction("DisplayPropertyDetails", "Property");

        }
    }
}