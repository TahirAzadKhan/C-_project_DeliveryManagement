using Delivarymanagement.Entities;
using Delivarymanagement.Interfaces;
using Delivarymanagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Services
{
    public class ProductService
    {
        IRepository<Product> repo;
        public ProductService()
        {
            this.repo = new ProductRepository();
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAll();
        }
        public List<Product> GetProductById(int id)
        {
            var data = repo.Get(id);
            Product product = new Product();
            product.Id = data.Id;
            product.ProductName = data.ProductName;
            product.Price = data.Price;
            product.Quantity = data.Quantity;
            
            List<Product> list = new List<Product>();
            list.Add(product);
            return list;
        }

        public int AddProduct(string name,float price,int quantity,int catId,string itemdestination,string ownername,int ownercontact)
        {
          
            int result = repo.Insert(new Product() {ProductName=name,Price=price,Quantity=quantity,CatId=catId, itemDestination = itemdestination, ownerName = ownername, ownerContact = ownercontact });
            return result;
        }

        public int EditProduct(int id, string name, float price, int quantity, int catId)
        {
           
            int result = repo.Update(new Product() { Id = id, ProductName = name, Price = price, Quantity = quantity, CatId = catId });
            return result;
        }

        public int RemoveProduct(int id)
        {
            int result = repo.Delete(id);
            return result;
        }
    }
}
