using Microsoft.AspNetCore.Mvc;
using Project.Domain.Data;
using Project.Domain.Models;
using Project.Services.ICustomServices;

namespace Project.WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICustomService<Product> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductController(ICustomService<Product> customService,
        ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetProductById))]
        public IActionResult GetProductById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllProducts))]
        public IActionResult GetAllProducts()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateProduct))]
        public IActionResult CreateProduct(Product product)
        {
            if (product != null)
            {
                _customService.Insert(product);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateProduct))]
        public IActionResult UpdateProduct(Product product)
        {
            if (product != null)
            {
                _customService.Update(product);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(Product product)
        {
            if (product != null)
            {
                _customService.Delete(product);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }

}
