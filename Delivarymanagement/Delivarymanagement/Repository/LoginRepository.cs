using Delivarymanagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Repository
{
    public class LoginRepository
    {
        DataAccess dataAccess;
        public LoginRepository()
        {
            dataAccess = new DataAccess();
        }

        public int Validation(User user)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Credentials WHERE Username='"+user.Username+"' AND Password='"+user.Password+"'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            int userType = (int)reader["UserType"];
            if (userType == 1)
            {
                return 1;
            }
            else if (userType == 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
