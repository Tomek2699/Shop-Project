using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Shop;
using HealthyDay.Models.Shop.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthyDay.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private readonly ICrudProductRepository productRepository;
        private readonly ICrudCategoryRepository categoryRepository;

        public ShopController(ICrudProductRepository productRepository, ICrudCategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult ShopManagment()
        {
            return View();
        }

        // PRODUCT CRUD OPERATIONS

        [HttpGet]
        public IActionResult ProductsManagment()
        {
            return View(productRepository.FindAllProducts());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel item)
        {
            if(ModelState.IsValid)
            {
                productRepository.AddProduct(item);
                return View("AddProductConfirm", item);
            }
            else
            {
                return View("AddProduct");
            }
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
            return View("ProductsManagment", productRepository.FindAllProducts());
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            return View(productRepository.FindProduct(id));
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel item)
        {
            if(ModelState.IsValid)
            {
                productRepository.EditProduct(item);
                return View("ProductsManagment", productRepository.FindAllProducts());
            }
            else
            {
                return View("EditProduct", item);
            }
        }

        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            return View(productRepository.FindProduct(id));
        }

        // CATEGORY CRUD OPERATIONS

        [HttpGet]
        public IActionResult CategoriesManagment()
        {
            return View("./Category/CategoriesManagment", categoryRepository.FindAllCategories());
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View("./Category/AddCategory");
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryModel item)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.AddCategory(item);
                return View("./Category/AddCategoryConfirm", item);
            }
            else
            {
                return View("./Category/AddCategory");
            }
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
            return View("./Category/CategoriesManagment", categoryRepository.FindAllCategories());
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            return View("./Category/EditCategory", categoryRepository.FindCategory(id));
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel item)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.EditCategory(item);
                return View("./Category/CategoriesManagment", categoryRepository.FindAllCategories());
            }
            else
            {
                return View("./Category/EditCategory", item);
            }
        }

        [HttpGet]
        public IActionResult DetailsCategory(int id)
        {
            return View("./Category/DetailsCategory", categoryRepository.FindCategory(id));
        }

        [HttpGet]
        public IActionResult ProductsCategoriesManagment()
        {
            ViewData["Products"] = productRepository.FindAllProducts();
            ViewData["Categories"] = categoryRepository.FindAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult AddProductToCategory(ProductCategoryModel model)
        {
            try
            {
                categoryRepository.AddProductToCategory(model);
                return View("ShopManagment");
            }
            catch(DbUpdateException)
            {
                ViewData["Products"] = productRepository.FindAllProducts();
                ViewData["Categories"] = categoryRepository.FindAllCategories();
                ModelState.AddModelError(string.Empty, "Produkt już posiada tą kategorie");
                return View("ProductsCategoriesManagment");
            }
             
        }
    }
}