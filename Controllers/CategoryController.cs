using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.Web.CodeGeneration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;
        public CategoryController(ICategoryService _categoryService)
        {
            this.categoryService = _categoryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var categorys = await this.categoryService.Categorys();

            return Ok(categorys);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (id > 0)
            {
                var categorys = await this.categoryService.GetCategory(id);
                if (categorys == null)
                {
                    return NoContent();
                }
                return Ok(categorys);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var categorys = await this.categoryService.GetCategory(id);
            if (categorys != null)
            {
                categorys.Name = category.Name;
                categorys.Description = category.Description;
                categorys.Caption = category.Caption;
                categorys.IsActive = category.IsActive;
                var response = await this.categoryService.Update(categorys);
                if (response)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return BadRequest();
                }
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var response = await this.categoryService.Create(category);
            if (response)
            {
                return Ok("Category Added Successfully");
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id > 0)
            {
                var response = await this.categoryService.Delete(id);
                if (response)
                {
                    return Ok("Deleted Successfully");
                }
            }
            return NoContent();
        }
    }
}
