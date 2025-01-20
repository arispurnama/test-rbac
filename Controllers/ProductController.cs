//using ApiCrud.DataBase;
//using ApiCrud.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ApiCrud.Controllers
//{
//    [ApiController]
//    [Route("Product")]
//    public class ProductController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public ProductController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Products
//        [HttpGet]
//        public async Task<IActionResult> GetProducts()
//        {
//            var result = await _context.Products.ToListAsync();
//            return StatusCode(200, result);
//        }
//        // POST: api/Products
//        [HttpPost]
//        public async Task<IActionResult> PostProduct(ProductsRequest product)
//        {
//            try
//            {
//                var req = new Products
//                {
//                    Name = product.Name,
//                    Price = product.Price,
//                    Description = product.Description,
//                };
//                _context.Products.Add(req);
//                await _context.SaveChangesAsync();

//                return StatusCode(200, "Berhasil!!!");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        // PUT: api/Products/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProduct(int id, UpdateProductsRequest product)
//        {
//            try
//            {
//                if (id != product.Id)
//                {
//                    return BadRequest();
//                }
//                var req = new Products
//                {
//                    Id = id,
//                    Name = product.Name,
//                    Price = product.Price,
//                    Description = product.Description,
//                };
//                _context.Entry(req).State = EntityState.Modified;
//                await _context.SaveChangesAsync();

//                return StatusCode(200, "Berhasil di Update!!!");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        // DELETE: api/Products/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            try
//            {
//                var product = await _context.Products.FindAsync(id);
//                if (product == null)
//                {
//                    return NotFound();
//                }

//                _context.Products.Remove(product);
//                await _context.SaveChangesAsync();

//                return StatusCode(200, "Berhasil di Deleted!!!");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        // GET: api/Products/byid
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProduct(int id)
//        {
//            var product = await _context.Products.FindAsync(id);

//            if (product == null)
//            {
//                return NotFound();
//            }

//            return Ok(product);
//        }
//    }
//}
