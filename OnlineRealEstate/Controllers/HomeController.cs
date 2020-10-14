using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineRealEstate.Controllers
{

    public class HomeController : Controller
    {
        PropertyBL propertyBL = new PropertyBL();

        // GET: Home
        [HttpGet]
        public ActionResult Search()
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            IEnumerable<string> locationList = propertyBL.GetLocation();
            ViewBag.propertyType = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            ViewBag.location = new SelectList(locationList);
            return View();
        }
        [HttpPost]
        public ActionResult Search(PropertyModel propertyModel)
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            IEnumerable<string> locationList = propertyBL.GetLocation();
            ViewBag.propertyType = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            ViewBag.location = new SelectList(locationList);
            int propertyId, propertyTypeId;
            IEnumerable<PropertyValues> propertyValues = new List<PropertyValues>();
            IEnumerable<PropertyFeature> propertyFeatures = new List<PropertyFeature>();
            List<Property> property=propertyBL.SearchByLocation(propertyModel.Location, propertyModel.PropertyTypeID);
            if(property.Count!=0)
            {
                for (int index = 0; index < property.Count; index++)
                {
                    propertyId = Convert.ToInt32(property[index].PropertyId);
                    propertyTypeId = Convert.ToInt32(property[index].PropertyTypeID);
                    propertyValues=(propertyBL.GetPropertyValueDetails(propertyId)); 
                    propertyFeatures=(propertyBL.GetPropertyFeatureDetails(propertyTypeId));

                }
                TempData["Property"] = property;
                TempData["PropertyFeature"] = propertyFeatures;
                TempData["PropertyValue"] = propertyValues;
                return RedirectToAction("DisplayByLocation");
            }
            else
            {
                ViewBag.Message = "There is no property :(";
                return View();
            }
           

        }
        public ActionResult DisplayByLocation()
        {
            return View();
        }

    }
}