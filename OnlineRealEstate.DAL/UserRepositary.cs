using OnlineRealEstate.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRealEstate.DAL
{
    public class UserRepositary
    {
        List<User> userList = new List<User>();
        public int SignUp(User user)
        {
            PropertyContext propertyContext = new PropertyContext();
            propertyContext.User.Add(user);
            return propertyContext.SaveChanges();
        }
        public User Login(User user)
        {
            PropertyContext propertyContext = new PropertyContext();
            user = propertyContext.User.Where(userDetail=>userDetail.Email==user.Email && userDetail.Password==user.Password).FirstOrDefault();
            return user;
         
        }
        public List<Property> GetPropertyDetailsByUserId(int userId)
        {
            using(PropertyContext propertyContext=new PropertyContext())
            {
                return (from property in propertyContext.Property where userId == property.UserId select property).ToList();
            }
        }
    }
}
