using Delivarymanagement.Entities;
using Delivarymanagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Services
{
    public class RegistrationService
    {
        RegistrationRepository regRepo;
        public RegistrationService()
        {
            regRepo = new RegistrationRepository();
        }
        public int UserRegistration(string name, string email, string phone, string username, string password, int userType)
        {
            return regRepo.Register(new User(){Name=name,Email= email,Phone= phone,Username= username,Password= password,UserType= userType});
        }
    }
}
