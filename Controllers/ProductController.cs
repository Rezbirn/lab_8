using lab_8.DbContext;
using lab_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApiDbContext _db;
        public ProductController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpGet("gets")]
        public IActionResult GetProducts() 
        {
            var products = _db.Products.ToList();
            if(products is not null && products.Any())
                return Ok(products);
            return NotFound();
        }

        [HttpGet("get")]
        public IActionResult GetProduct(int id)
        {
            var product = _db.Products.Where(x=>x.Id == id).FirstOrDefault();
            if(product is not null)
                return Ok(product);

            return NotFound();
        }

        [HttpPost("create")]
        public IActionResult CreateProduct(ProductModel model) 
        {
            if (!model.IsValid)
                return BadRequest();

            var product = new Product(model.Name, model.Description, model.Price, model.Amount);
            _db.Products.Add(product);
            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(int id) 
        {
            var product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product is null)
                return BadRequest();
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult UpdateProduct(int id, ProductModel model)
        {
            if (!model.IsValid)
                return BadRequest();

            var product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product is null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Amount = model.Amount;
            _db.SaveChanges();
            return Ok();
        }
    }
}
