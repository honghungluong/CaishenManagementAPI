using CaishenManagementAPI.Datacontext;
using CaishenManagementAPI.Entity;
using CaishenManagementAPI.Models.DTO;
using CaishenManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaishenManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CaishenMngtDbContext context;
        private readonly IProductRepository productRepository;

        public ProductController(CaishenMngtDbContext context, IProductRepository productRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await productRepository.GetAll();
            if (products == null || !products.Any())
                return NotFound();
            var productDTOs = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImportPrice = p.ImportPrice,
                SellPrice = p.SellPrice,
                StockQuantity = p.StockQuantity,
                Status = p.Status,
                Type = p.Type // Added Type mapping
            }).ToList();
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await productRepository.GetById(id);
            if (product == null) return NotFound();

            var dto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImportPrice = product.ImportPrice,
                SellPrice = product.SellPrice,
                StockQuantity = product.StockQuantity,
                Status = product.Status,
                Type = product.Type // Added Type mapping
            };

            return Ok(dto);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                ImportPrice = dto.ImportPrice,
                SellPrice = dto.SellPrice,
                StockQuantity = dto.StockQuantity,
                Status = dto.Status,
                Type = dto.Type // Added Type mapping
            };

            await productRepository.Add(product);

            var resultDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImportPrice = product.ImportPrice,
                SellPrice = product.SellPrice,
                StockQuantity = product.StockQuantity,
                Status = product.Status,
                Type = product.Type // Added Type mapping
            };

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, resultDto);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO dto)
        {
            var existingProduct = await productRepository.GetById(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = dto.Name;
            existingProduct.Description = dto.Description;
            existingProduct.ImportPrice = dto.ImportPrice;
            existingProduct.SellPrice = dto.SellPrice;
            existingProduct.StockQuantity = dto.StockQuantity;
            existingProduct.Status = dto.Status;
            existingProduct.Type = dto.Type; // Added Type mapping

            await productRepository.Update(existingProduct);

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productRepository.GetById(id);
            if (product == null) return NotFound();

            await productRepository.Delete(product);
            return NoContent();
        }

        // DELETE: api/products
        [HttpDelete]
        public async Task<IActionResult> DeleteAllProducts()
        {
            var products = await productRepository.GetAll();
            if (products == null || !products.Any())
                return NotFound();

            foreach (var product in products)
            {
                await productRepository.Delete(product);
            }

            return NoContent();
        }
    }
}
