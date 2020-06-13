using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            this._repo = repo;


        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            if (products != null)
            {
                return Ok(products);
            }

            return BadRequest("Error does not exist");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return BadRequest("Product not found");
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _repo.GetProductBrandsAsync();

            if (brands != null)
            {
                return Ok(brands);
            }

            return BadRequest("No brands saved");
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await _repo.GetProductTypesAsync();

            if (types != null)
            {
                return Ok(types);
            }

            return BadRequest("no types saved");
        }

    }
}