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
    public class ProductRepository:IRepository<Product>
    {
        DataAccess dataAccess;
        public ProductRepository()
        {
            this.dataAccess = new DataAccess();
        }
        public List<Product> GetAll()
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Product> productList = new List<Product>();
            while(reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["ProductId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToSingle(reader["Price"]);
                product.Quantity = Convert.ToInt32(reader["Quantity"]);
                product.CatId = Convert.ToInt32(reader["CategoryId"]);
                product.itemDestination = reader["Itemdestination"].ToString();
                product.ownerName = reader["Ownername"].ToString();
                product.ownerContact = Convert.ToInt32(reader["Ownercontact"]);
                productList.Add(product);
            }
            dataAccess.Dispose();
            return productList;
        }

        public Product Get(int id)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Products WHERE ProductId="+id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Product product = new Product();
            product.Id = Convert.ToInt32(reader["ProductId"]);
            product.ProductName = reader["ProductName"].ToString();
            product.Price = Convert.ToSingle(reader["Price"]);
            product.Quantity = Convert.ToInt32(reader["Quantity"]);
            product.CatId = Convert.ToInt32(reader["CategoryId"]);
            product.itemDestination = reader["Itemdestination"].ToString();
            product.ownerName = reader["Ownername"].ToString();
            product.ownerContact = Convert.ToInt32(reader["Ownercontact"]);

            dataAccess.Dispose();
            return product;
        }

        public int Insert(Product entity)
        {
            dataAccess = new DataAccess();
            string sql = "INSERT INTO Products(ProductName,Price,Quantity,CategoryId,Itemdestination,Ownername,Ownercontact) VALUES('" + entity.ProductName + "'," + entity.Price + "," + entity.Quantity + "," + entity.CatId + ",'" + entity.itemDestination + "','" + entity.ownerName + "'," + entity.ownerContact + ")";
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Update(Product entity)
        {
            dataAccess = new DataAccess();
            
            string sql = "update Products Set ProductName='" +entity.ProductName + "',Price=" + entity.Price + ",Quantity=" + entity.Quantity + ",CategoryId=" + entity.CatId + "WHERE ProductId=" + entity.Id + "";
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Delete(int id)
        {
            dataAccess = new DataAccess();
            string sql = "DELETE FROM Products WHERE ProductId=" + id;
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }
    }
}
