using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using proyecto1.Data;
using proyecto1.Models;


namespace proyecto1.Services.Interfaces
{
    public class ProductosServices : IProductosServices
    {
        private readonly AppDbContext _context;

        public ProductosServices(AppDbContext productoContext)
        {
            _context = productoContext;
        }

        public async Task<IEnumerable<Producto>> Get(int id)
        {
            var producto = _context.Productos.Where(p => p.Id == id);

            return await producto.ToListAsync();


        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }


        public async Task<Producto> Add(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> Update(Producto producto)
        {
            var productoCambio = await _context.Productos.SingleAsync(x => x.Id == producto.Id);

            productoCambio.Nombre = producto.Nombre;
            productoCambio.Precio = producto.Precio;
            productoCambio.Stock = producto.Stock;

            _context.Productos.Update(productoCambio);
            await _context.SaveChangesAsync();
            
            return producto;
        }


        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return false;
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }




    }


    public interface IProductosServices
    {
        Task<IEnumerable<Producto>> Get(int id);

        Task<IEnumerable<Producto>> GetAll();

        Task<Producto> Add(Producto producto);

        Task<Producto> Update(Producto producto);

        Task<bool> Delete(int id);

    }
}
