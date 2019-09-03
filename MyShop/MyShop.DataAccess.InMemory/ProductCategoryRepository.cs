﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategories;

        public ProductCategoryRepository()
        {
            productsCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productsCategories == null)
            {
                productsCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCategories"] = productsCategories;
        }




        public void Insert(ProductCategory p)
        {
            productsCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productsCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productsCategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Prodcut Category not found ");
            }
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productsCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productsCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Prodcut not found ");
            }

        }



        public IQueryable<ProductCategory> Collection()
        {
            return productsCategories.AsQueryable();
        }

    }
}
