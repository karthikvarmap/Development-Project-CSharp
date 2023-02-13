using Interview.Web.Models;
using Interview.Web.Interfaces;
using Interview.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Web.Contracts.V1;

namespace Interview.Web.Controllers
{

    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }// NOTE: Sample Actione

        [Route("api/v1/products")]
        [HttpGet]
        public Task<IActionResult> GetAllProducts()
        {
            return Task.FromResult((IActionResult)Ok(new object[] { }));
        }

        [Route("api/v1/productByName")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsByName(string Name="Ca")
        {
            return await _productRepository.GetProductsByName(Name);
        }


        [Route("api/v1/Addproduct")]
        [HttpPost]
        public async void AddProduct([FromBody] ProductV1 product)
        {
             await _productRepository.AddProductAsync(product);
        }

        [Route("api/v1/addCategory")]
        [HttpPost]
        public async Task<int> AddCategory([FromBody] Categories category)
        {
            return await _productRepository.AddCategory(category);
        }

        [Route("api/v1/addCategoryAttributes")]
        [HttpPost]
        public async Task AddCategoryAttributes([FromBody] IEnumerable<CategoryAttributes> categoryAttributes)
        {
            await _productRepository.AddCategoryAttributes(categoryAttributes);
        }

        [Route("api/v1/getAllCategories")]
        [HttpGet]
        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            return await _productRepository.GetAllCategories(); 
        }

        [Route("api/v1/getCategoryAttributes/{categoryId}")]
        [HttpGet]
        public async Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId)
        {
            return await _productRepository.GetCategoryAttributes(categoryId);
        }

        [Route("api/v1/associateProductWithCategory/{productId}/{categoryId}")]
        [HttpPost]
        public async Task AssociateProductWithCategory(int productId, int categoryId)
        {
            await _productRepository.AssociateProductWithCategory(productId, categoryId);
        }

        [Route("api/v1/addCategoryAttributes")]
        [HttpPost]
        public async Task AddProductAttributes([FromBody] IEnumerable<ProductAttributes> productAttributes)
        {
            await _productRepository.AddProductAttributes(productAttributes);
        }
        [Route("api/v1/deleteProduct/{productId}")]
        [HttpDelete]

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }

    }
}
