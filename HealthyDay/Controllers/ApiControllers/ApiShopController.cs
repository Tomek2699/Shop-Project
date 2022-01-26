using HealthyDay.Models.Shop;
using HealthyDay.Models.Shop.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Controllers.ApiControllers
{
    [ApiController]
    [Route("ApiShop")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiShopController : Controller
    {
        private readonly ICrudProductRepository productRepository;
        private readonly ICrudCategoryRepository categoryRepository;

        public ApiShopController(ICrudProductRepository productRepository, ICrudCategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        // CRUD PRODUCT OPERATIONS

        [AllowAnonymous]
        [HttpGet]
        [Route("FindProducts")]
        public IList<ProductModel> ProductsManagment()
        {
            return productRepository.FindAllProducts();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("FindProduct/{id}")]
        public ProductModel FindProduct(int id)
        {
            return productRepository.FindProduct(id);
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductModel item)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(item);
                return new CreatedResult($"/ApiShop", item);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
            return new CreatedResult($"/ApiShop", $"Udało Ci się usunąć produkt o ID: {id}");
        }

        [HttpPost]
        [Route("EditProduct")]
        public IActionResult EditProduct(ProductModel item)
        {
            if (ModelState.IsValid)
            {
                productRepository.EditProduct(item);
                return new CreatedResult($"/ApiShop", item);
            }
            else
            {
                return BadRequest();
            }
        }

        // CRUD CATEGORIES OPERATIONS

        [HttpGet]
        [Route("FindCategories")]
        public IList<CategoryModel> CategoriesManagment()
        {
            return categoryRepository.FindAllCategories();
        }

        [HttpGet]
        [Route("FindCategory/{id}")]
        public CategoryModel FindCategory(int id)
        {
            return categoryRepository.FindCategory(id);
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory(CategoryModel item)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.AddCategory(item);
                return new CreatedResult($"/ApiShop", item);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
            return new CreatedResult($"/ApiShop", $"Udało Ci się usunąć kategorie o ID: {id}");
        }

        [HttpPost]
        [Route("EditCategory")]
        public IActionResult EditCategory(CategoryModel item)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.EditCategory(item);
                return new CreatedResult($"/ApiShop", item);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
