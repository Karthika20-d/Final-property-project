using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRealEstate.Controllers
{
    public class BuyerController : Controller
    {
        PropertyBL propertyBL = new PropertyBL();
        // GET: User
        public ActionResult Create()
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            return View();
        }
        [HttpPost]
        public ActionResult Create(BuyerPropertyModel propertyModel, HttpPostedFileBase fileBase)
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            BuyerProperty property = new BuyerProperty();
            propertyModel.UserId = (int)TempData["UserId"];
            if (fileBase != null && fileBase.ContentLength > 0)
            {

                var fileName = Path.GetFileName(fileBase.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                fileBase.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                propertyModel.Image = new byte[fileBase.ContentLength];
                fileBase.InputStream.Read(propertyModel.Image, 0, fileBase.ContentLength);
                propertyModel.Status = "Reject";
                property = AutoMapper.Mapper.Map<BuyerPropertyModel,BuyerProperty>(propertyModel);
                if (propertyBL.Create(property) > 0)
                {
                    ViewBag.Message = "Your property registration is under processed";
                    
                }
                else
                {
                    ViewBag.Message = "failed";
                }
            }
            return View();
        }
        public ActionResult DisplayBuyerPropertyDetails()
        {
            return View();
        }
        public ActionResult PropertyStatus()
        {
            int id = (int)TempData["UserId"];
            BuyerProperty property = propertyBL.DisplayBuyerPropertyByID(id);
            TempData["Property"] = property;
            return View();
        }
    }
}