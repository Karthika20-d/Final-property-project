using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineRealEstate.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            User user = new User();
            UserBL userBL = new UserBL();
            if (ModelState.IsValid)
            {
                user.Name = signUpModel.Name;
                user.Email = signUpModel.Email;
                user.PhoneNumber = signUpModel.PhoneNumber;
                user.Role = signUpModel.Role.ToString();
                user.Location = signUpModel.Location;
                user.Password = signUpModel.Password;
                if (userBL.SignUp(user) > 0)
                {
                    ViewBag.Message = "Register successfull";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            User user = new User();
            UserBL userBL = new UserBL();
            if (ModelState.IsValid)
            {
                user.Email = loginModel.Email;
                user.Password = loginModel.Password;
                user = userBL.Login(user);
                if (user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("DisplayPropertyDetails", "Property");
                    }
                    else if (user.Role == "Buyer")
                    {
                        PropertyBL propertyBL = new PropertyBL();
                        List<Property> property = userBL.GetPropertyDetailsByUserId(user.UserId);
                        List<int> propertyValues = new List<int>();
                        List<string> propertyFeatures = new List<string>();
                        for (int index = 0; index < property.Count; index++)
                        {
                            propertyValues[index] = Convert.ToInt32(propertyBL.GetPropertyValueDetails(Convert.ToInt32(property[index].PropertyId)));
                            propertyFeatures[index] = Convert.ToString(propertyBL.GetPropertyFeatureDetails(Convert.ToInt32(property[index].PropertyTypeID)));

                        }
                        TempData["Property"] = property;
                        TempData["PropertyFeature"] = propertyFeatures;
                        TempData["PropertyValue"] = propertyValues;
                        return RedirectToAction("DisplayBuyerPropertyDetails");
                    }
                    else
                    {
                        ViewBag.Message = "Login failed";
                    }
                }
                else
                {
                    ViewBag.Message = "Login failed";
                }

            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Search", "Home");
        }
        public ActionResult DisplayBuyerPropertyDetails()
        {
            return View();        }
    }
}