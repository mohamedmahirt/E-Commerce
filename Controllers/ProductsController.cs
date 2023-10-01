using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await this.productService.Products();

            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if(id > 0)
            {
                var products = await this.productService.GetProduct(id);
                if(products == null)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            else
            {
                return BadRequest();
            }
           
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var products = await this.productService.GetProduct(id);
            if (products != null)
            {
                products.Name = product.Name;
                products.Description = product.Description;
                products.CategoryId = product.CategoryId;
                products.Caption = product.Caption;
                products.ProductCode = product.ProductCode;
                products.Color = product.Color;
                products.IsActive = product.IsActive;
                products.SaleAmount = product.SaleAmount;
                products.IsFeatured = product.IsFeatured;
                products.PurchaseAmount = product.PurchaseAmount;
                products.ModifiedDate = DateTime.UtcNow;
                var response = await this.productService.Update(products);
                if(response)
                {
                    return Ok("Updated Successfully");
                }
                else { 
                    return BadRequest(); 
                }
            }
            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var response = await this.productService.Create(product);
            if(response)
            {
                return Ok("Product Added Successfully");
            }
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id > 0)
            {
                var response = await this.productService.Delete(id);
                if (response)
                {
                    return Ok("Deleted Successfully");
                }
            }
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return false;
        }
    }
}
