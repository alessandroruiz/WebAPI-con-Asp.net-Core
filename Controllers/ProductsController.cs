using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto1.Models;
using proyecto1.Services.Interfaces;

namespace proyecto1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductosServices _productosServices;

        public ProductsController(IProductosServices productosServices)
        {
            _productosServices = productosServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _productosServices.GetAll();
            if (productos == null)
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet("productoId")]
        public async Task<IActionResult> Get(int id) 
        {
            var productos = await _productosServices.Get(id);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpPost]

        public async Task<IActionResult> Add(Producto producto)
        {
            var nuevoProducto = await _productosServices.Add(producto);
            return Ok(nuevoProducto);
        }

        [HttpPut]
        
        public async Task<IActionResult> Update(Producto producto, int id)
        {
            var productos = await _productosServices.Get(id);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }

            var productoActualizado = await _productosServices.Update(producto);
            if (productoActualizado == null)
            {
                return NotFound();
            }
            return Ok(productoActualizado);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var productos = await _productosServices.Get(id);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            var productoEliminado = await _productosServices.Delete(id);
            
            return Ok(productoEliminado);
        }
    }
}
