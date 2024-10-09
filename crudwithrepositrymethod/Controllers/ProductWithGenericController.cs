using crudwithrepositrymethod.Entity;
using crudwithrepositrymethod.Repository;
using crudwithrepositrymethod.VeiwModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudwithrepositrymethod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithGenericController : ControllerBase
    {
        private readonly IRepository<Product> _productRespository;

        public ProductWithGenericController(IRepository<Product> productRespository)
        {
            _productRespository = productRespository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRespository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRespository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ProductRequest product)
        {
            var productEnity = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,
            };

            var createdProductResponse = await _productRespository.AddAsync(productEnity);
            return CreatedAtAction(nameof(GetById), new { id = createdProductResponse.ProductId }, createdProductResponse);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] ProductRequest product)
        {
            var productEntity = await _productRespository.GetByIdAsync(id);
            if(productEntity == null)
            {
                return NotFound();
            }
            productEntity.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            await _productRespository.UpdateAsync(productEntity);
            return NoContent();
        }

        [HttpDelete("{id}" +
            "" +
            "")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRespository.GetByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }

            await _productRespository.DeleteAsync(product);
            return NoContent();

        }
    }
}
