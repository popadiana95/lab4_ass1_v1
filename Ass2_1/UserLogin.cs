using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2_1
{
    public class UserLogin
    {
        public User Login(string userName, string password)
        {
            DataBaseAccess dal = new DataBaseAccess();
            User user = dal.GetUser(userName);
            if (user != null)
            {
                Security secure = new Security();
                if (secure.VerifyHash(password, user.pass))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            Security secure = new Security();
            user.pass = secure.HashSHA1(user.pass);
            DataBaseAccess dal = new DataBaseAccess();
            dal.AddUser(user);
        }
    }
}
