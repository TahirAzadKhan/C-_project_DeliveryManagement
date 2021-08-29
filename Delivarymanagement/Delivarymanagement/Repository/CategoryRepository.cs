using Delivarymanagement.Entities;
using Delivarymanagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        DataAccess dataAccess;
        public CategoryRepository()
        {
            this.dataAccess = new DataAccess();
        }
        public List<Category> GetAll()
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Category> categoryList = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.CatId = Convert.ToInt32(reader["CategoryId"]);
                category.CatName= reader["CategoryName"].ToString();
                categoryList.Add(category);
            }
            dataAccess.Dispose();
            return categoryList;
        }
        public List<string> GetAllCategoryNames()
        {
            dataAccess = new DataAccess();
            string sql = "SELECT CategoryName FROM Categories";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<string> categoryList = new List<string>();
            while (reader.Read())
            {
               
                categoryList.Add(reader["CategoryName"].ToString());
            }
            dataAccess.Dispose();
            return categoryList;
 
        }

        public int GetIdByName(string name)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT CategoryId FROM Categories WHERE CategoryName='" + name+"'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
           int result=Convert.ToInt32(reader["CategoryId"]);
            
            dataAccess.Dispose();
            return result;
 
        }
        public Category Get(int id)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Categories WHERE CategoryId=" + id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Category category = new Category();
            category.CatId = Convert.ToInt32(reader["CategoryId"]);
            category.CatName = reader["CategoryName"].ToString();
            dataAccess.Dispose();
            return category;
        }

        public int Insert(Category entity)
        {
            dataAccess = new DataAccess();
            string sql = "INSERT INTO Categories(CategoryName) VALUES('" + entity.CatName + "')";
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Update(Category entity)
        {
            dataAccess = new DataAccess();
            string sql = "UPDATE Categories SET CategoryName='" + entity.CatName + "' WHERE CategoryId=" + entity.CatId;
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Delete(int id)
        {
            dataAccess = new DataAccess();
            string sql = "DELETE FROM Categories WHERE CategoryId=" + id;
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }
    }
}
