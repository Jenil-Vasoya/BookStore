using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetCategories(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Records = categories.Records.Select(c => new CategoryModel(c)).ToList(),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategories(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categoryModel = new CategoryModel(category);

            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCategories(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };

            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCategories(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };

            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategories(int id)
        {
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }

    }
}
