using Delivarymanagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Repository
{
    public class RegistrationRepository
    {
        DataAccess dataAccess;
        public RegistrationRepository()
        {
            dataAccess = new DataAccess();
        }

        public int Register(User user)
        {
            dataAccess = new DataAccess();
            string sql = "INSERT INTO Users(Name,Email,Phone) VALUES('" + user.Name + "','" + user.Email+ "','" + user.Phone+ "')";
            int result = dataAccess.ExecuteQuery(sql);
            if (result > 0)
            {
                dataAccess = new DataAccess();
                sql = "SELECT * FROM Users WHERE Email='" + user.Email + "'";
                SqlDataReader reader = dataAccess.GetData(sql);
                reader.Read();
                int id = (int)reader["UserId"];

                dataAccess = new DataAccess();
                sql = "INSERT INTO Credentials(Username,Password,UserType,UserId) VALUES('" + user.Username + "','" + user.Password+ "'," + user.UserType+ "," + id + ")";
                result = dataAccess.ExecuteQuery(sql);
                if (result > 0)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }
    }
}
