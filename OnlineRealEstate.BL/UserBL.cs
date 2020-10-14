using OnlineRealEstate.DAL;
using OnlineRealEstate.Entity;
using System.Collections.Generic;

namespace OnlineRealEstate.BL
{
    public class UserBL
    {
        UserRepositary userRepositary = new UserRepositary();
        public int SignUp(User user)
        {
            return userRepositary.SignUp(user);
        }
        public User Login(User user)
        {
            return userRepositary.Login(user);
        }
        public List<Property> GetPropertyDetailsByUserId(int userId)
        {
            return userRepositary.GetPropertyDetailsByUserId(userId);
        }



    }
}
