using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using VShop.ProductApi.Context;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsCategories()
        {
            return await _context.products.Include(C => C.caterory).ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await _context.products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Product> Create(Product product)
        {
           _context.products.Add(product);
           await _context.SaveChangesAsync();
           return product;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> DeleteById(int id)
        {
            var product = await GetById(id);
            _context.Remove(product);
            await _context.SaveChangesAsync(); 
            return product;
        }
    }
}
