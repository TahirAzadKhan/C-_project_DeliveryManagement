using Delivarymanagement.Entities;
using Delivarymanagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Services
{
    public class LoginService
    {
        LoginRepository loginRepo;
        public LoginService()
        {
            loginRepo = new LoginRepository();
        }

        public int LoginValidation(string username, string password)
        {
            return loginRepo.Validation(new User(){Username= username,Password= password});
        }
    }

}
