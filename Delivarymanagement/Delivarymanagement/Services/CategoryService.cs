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
    public class CategoryService
    {
        IRepository<Category> repo;
        CategoryRepository catRepo;
        public CategoryService()
        {
            this.repo = new CategoryRepository();
            this.catRepo = new CategoryRepository();
        }

        public List<Category> GetAllCategories()
        {
            return repo.GetAll();
        }
        public List<string> GetAllCategoryNames()
        {
            return catRepo.GetAllCategoryNames();
        }
        public List<Category> GetCategoryById(int id)
        {
            var data = repo.Get(id);
            Category category = new Category();
            category.CatId= data.CatId;
            category.CatName = data.CatName;
            List<Category> list = new List<Category>();
            list.Add(category);
            return list;
        }
        public int GetIdByName(string name)
        {
            var data = catRepo.GetIdByName(name);
            
            return data;
        }

        public int AddCategory(string name)
        {
            //Product product = new Product();
            //product.Name = name;
            //product.Price = price;
            int result = repo.Insert(new Category() { CatName= name});
            return result;
        }

        public int EditCategory(int id, string name)
        {
            //Product product = new Product();\
            //Product.Id = id;
            //product.Name = name;
            //product.Price = price;
            int result = repo.Update(new Category() { CatId = id, CatName= name});
            return result;
        }

        public int RemoveCategory(int id)
        {
            int result = repo.Delete(id);
            return result;
        }
    }
}
