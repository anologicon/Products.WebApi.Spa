using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.WebApi.Entities;
using Products.WebApi.Model;
using Products.WebApi.Services;

namespace Products.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<ProductEntity> Create(ProductModel productModel)
        {
            try
            {
                ProductEntity product = _productService.NewProduct(productModel);

                return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<List<ProductEntity>> Get () =>
            _productService.Get ();

        [HttpGet ("{id}", Name = "GetProduct")]
        public ActionResult<ProductEntity> Get (int id) {
            
            var product = _productService.Get (id);

            if (product == null) {
                return NotFound ();
            }

            return product;
        }
        
        [HttpPut ("{id}")]
        public IActionResult Update (int id, ProductModel productModelIn) {
            
            var product = _productService.Get (id);

            if (product == null) {
                return NotFound ();
            }

            _productService.Update(product, productModelIn);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Remove(product);

            return NoContent();
        }
    }
}