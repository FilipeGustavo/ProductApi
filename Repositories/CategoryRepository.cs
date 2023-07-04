using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using VShop.ProductApi.Context;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.categories.ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            return await _context.categories.Include(c => c.Products).ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await _context.categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }
        public async Task<Category> Create(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await GetById(id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
