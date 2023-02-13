using Interview.Web.Contracts.V1;
using Interview.Web.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Web.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByName(string Name);
        Task AddProductAsync(ProductV1 product);
        Task UpdateProductAsync(Product product);
        Task<int> AddCategory(Categories category);
        Task<IEnumerable<Categories>> GetAllCategories();
        Task AddCategoryAttributes(IEnumerable<CategoryAttributes> categoryAttributes);
        Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId);
        Task AssociateProductWithCategory(int productId, int categoryId);
        Task AddProductAttributes(IEnumerable<ProductAttributes> productAttributes);
        Task DeleteProductAsync(int productId);
        
        }
}
