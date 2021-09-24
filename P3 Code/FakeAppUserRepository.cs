using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Code
{
    public class FakeAppUserRepository : IAppUserRepository
    {
        private static Dictionary<string, AppUser> AppUsers;
        public FakeAppUserRepository()
        {
            if (AppUsers == null)
            {
                AppUsers = new Dictionary<string, AppUser>();
                //Default Employees to wwork with
                AppUsers.Add("18Sensz", new AppUser
                {
                    Username = "18Sensz",
                    Password = "pass",
                    LastName = "Ensz",
                    FirstName = "Shawn",
                    EmailAddress = "fakeemail@gmail.com",
                    isAuthenticated = true,
                });
                AppUsers.Add("18Ben", new AppUser
                {
                    Username = "18Ben",
                    Password = "pass123",
                    LastName = "Schaeffer",
                    FirstName = "Ben",
                    EmailAddress = "realemail@gmail.com",
                    isAuthenticated = false,
                });
            }
        }
        public bool Login(string UserName, string Password)
        {
            AppUser appUser = GetByUserName(UserName);
            if(appUser != null)
            {
                if(appUser.Password == Password && appUser.isAuthenticated)
                {
                    //Success login
                    return true;
                }
                else
                {
                    //Incorrect creds or not authed
                    return false;
                }
            }
            else
            {
                //User does not exist
                return false;
            }
        }
        public List<AppUser> GetAll()
        {
            List<AppUser> appUsers = new List<AppUser>();
            foreach(KeyValuePair<string, AppUser> appUser in AppUsers)
            {
                appUsers.Add(appUser.Value);
            }
            return appUsers;
        }
        public void SetAuthentication(string UserName, bool isAuthenticated)
        {
            AppUser appUser = GetByUserName(UserName);
            if(appUser != null) {
                appUser.isAuthenticated = isAuthenticated;
                AppUsers[UserName] = appUser;
            }
            else
            {
                //User was not found -- return some exception or warning
            }
        }
        public AppUser GetByUserName(string UserName)
        {
            AppUser appUser = null;
            if (AppUsers.TryGetValue(UserName, out appUser))
            {
                return appUser;
            }
            //Some warning saying that username doesnt exist
            return null;
        }
    }
}
