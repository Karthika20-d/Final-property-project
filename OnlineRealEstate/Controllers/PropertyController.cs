using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Configuration;

namespace OnlineRealEstate.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PropertyController : Controller
    {
        PropertyBL propertyBL = new PropertyBL();
        List<int> FeatureKey = new List<int>()
;        // GET: Property
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            return View();
        }
        [HttpPost]
        //public ActionResult Create(PropertyModel propertyModel,HttpPostedFileBase fileBase )
        //{
        //    IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
        //    ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
        //    Property property = new Property();
        //    if (fileBase != null && fileBase.ContentLength > 0)
        //    {
             
        //        var fileName = Path.GetFileName(fileBase.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
        //        fileBase.SaveAs(path);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        propertyModel.Image = new byte[fileBase.ContentLength];
        //        fileBase.InputStream.Read(propertyModel.Image, 0, fileBase.ContentLength);
        //        property = AutoMapper.Mapper.Map<PropertyModel, Property>(propertyModel);
        //        if (propertyBL.Create(property) > 0)
        //        {
        //            TempData["TypeId"] = property;
        //            return RedirectToAction("AddFeature", "PropertyFeature");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "failed";
        //        }
        //    }
        //    return View();
        //}
        public List<int> GetFeatureValues(int id)
        {
            Dictionary<int, int> PropertyValues = propertyBL.EditPropertyValues(id);
            foreach (KeyValuePair<int, int> item in PropertyValues)
            {
                FeatureKey.Add(item.Key);

            }
            return FeatureKey;

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditModel editModel = new EditModel();
            List<int> values = new List<int>();
            Property propertyItems = propertyBL.Update(id);
            Dictionary<int, int> PropertyValues = propertyBL.EditPropertyValues(id);
            foreach (KeyValuePair<int, int> item in PropertyValues)
            {
                values.Add(PropertyValues[item.Key]);
            }
            editModel.FeatureValues = values;
            editModel.PropertyFeatures = propertyBL.EditPropertyFeatures(propertyItems.PropertyTypeID);
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            editModel.PropertyModel = AutoMapper.Mapper.Map<Property, PropertyModel>(propertyItems);
            return View(editModel);
        }
        [HttpPost]
        public ActionResult Edit(EditModel editModel, HttpPostedFileBase imageFile)
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            Property property = new Property();
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                imageFile.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                editModel.PropertyModel.Image= new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(editModel.PropertyModel.Image, 0, imageFile.ContentLength);
                property = AutoMapper.Mapper.Map<PropertyModel, Property>(editModel.PropertyModel);
                Dictionary<int, int> propertyValues = new Dictionary<int, int>();
                FeatureKey = GetFeatureValues(editModel.PropertyModel.PropertyId);
                for (int index = 0; index < FeatureKey.Count; index++)
                {
                    propertyValues.Add(FeatureKey[index], editModel.FeatureValues[index]);
                }
                propertyBL.UpdatePropertyDetails(property, propertyValues);
                return RedirectToAction("DisplayPropertyDetails");
            }
            return View();

        }
        [HttpGet]
        // [OutputCache(Duration =10)]
        public ActionResult DisplayPropertyDetails()
        {
            IEnumerable<Property> property = propertyBL.DisplayPropertyDetails();
            IEnumerable<PropertyValues> propertyValues = propertyBL.DisplayPropertyValueDetails();
            IEnumerable<PropertyFeature> propertyFeatures = propertyBL.DisplayPropertyFeatureDetails();
            TempData["Property"] = property;
            TempData["PropertyFeature"] = propertyFeatures;
            TempData["PropertyValue"] = propertyValues;
            //ViewBag.Message = DateTime.Now.ToString();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Property property = propertyBL.Update(id);
            PropertyModel propertyModel = AutoMapper.Mapper.Map<Property, PropertyModel>(property);
            return View(propertyModel);
        }
        [HttpPost]
        public ActionResult Delete(PropertyModel propertyModel)
        {
            propertyBL.Delete(propertyModel.PropertyId);
            return RedirectToAction("DisplayPropertyDetails");
        }


        //Buyer
        public ActionResult DisplayBuyerProperty()
        {
            IEnumerable<BuyerProperty> property = propertyBL.DisplayBuyerPropertyDetails();
            TempData["Property"] = property;
            return View();
        }
        public ActionResult AcceptProperty(int id)
        {
            BuyerProperty property = propertyBL.DisplayBuyerPropertyByID(id);
            propertyBL.AcceptRequest(property);
            return View();

        }
    }
}