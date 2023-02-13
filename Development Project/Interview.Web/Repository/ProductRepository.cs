using Interview.Web.Models;
using Interview.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Web.Contracts.V1;

namespace Interview.Web.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext _db;

        public ProductRepository(IMSContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string Name)
        {
           return await this._db.Products.Where(x => x.Name.Contains(Name)|| string.IsNullOrWhiteSpace(Name)).ToListAsync();       }

        public async Task AddProductAsync(ProductV1 product)
        {
            var productEntity = await _db.Products.AddAsync(new Product 
            { 
                Name = product.Name,
                Description = product.Description,
                ProductImageUris = product.ProductImageUris,
                ValidSkus = product.ValidSkus,
                CreatedTimestamp = product.CreatedTimestamp
            });
            await _db.SaveChangesAsync();
            var productId = productEntity.Entity.InstanceId;
            //Associate product with category
            await AssociateProductWithCategory(productId, product.CategoryInstanceId);
            //Insert product attributes
            await AddProductAttributes(product.ProductAttributes);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            _db.ProductCategories.RemoveRange(_db.ProductCategories.Where(pc => pc.InstanceId == productId));
            _db.ProductAttributes.RemoveRange(_db.ProductAttributes.Where(pa => pa.InstanceId == productId));
            _db.Products.Remove(_db.Products.Single(p => p.InstanceId == productId));
            await _db.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            var prod =  await this._db.Products.FindAsync(product.InstanceId);
            if (prod != null)
            {
                prod.Description = product.Description;
                prod.ValidSkus = product.ValidSkus;
                prod.Name = product.Name;
                prod.CreatedTimestamp =DateTime.Now;
                prod.ProductImageUris = product.ProductImageUris;
                await this._db.SaveChangesAsync();
            }
        }

        public async Task<int> AddCategory(Categories category)
        {
            var insertedCategory = await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return insertedCategory.Entity.InstanceId.Value;
        }

        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task AddCategoryAttributes(IEnumerable<CategoryAttributes> categoryAttributes)
        {
            await _db.CategoryAttributes.AddRangeAsync(categoryAttributes);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId)
        {
            return await _db.CategoryAttributes.Where(ca => ca.InstanceId == categoryId).ToListAsync();
        }

        public async Task AssociateProductWithCategory(int productId, int categoryId) 
        {
            var productCategory = new ProductCategories { InstanceId = productId, CategoryInstanceId = categoryId };
            await _db.ProductCategories.AddAsync(productCategory);
            await _db.SaveChangesAsync();
        }

        public async Task AddProductAttributes(IEnumerable<ProductAttributes> productAttributes)
        {
            await _db.ProductAttributes.AddRangeAsync(productAttributes);
            await _db.SaveChangesAsync();
        }
    }
}
