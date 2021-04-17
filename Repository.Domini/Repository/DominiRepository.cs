using Data.DominiCode.DBContext;
using Data.DominiCode.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Domini.Repository
{
    public class DominiRepository : IDominiRepository
    {
        private readonly DominiContext _context;

        public DominiRepository(DominiContext context)
        {
            this._context = context;
        }

        public async Task<List<ClientCategory>> GetClientCategories()
        {
            List<ClientCategory> categories = await _context.ClientCategories.ToListAsync();
            return categories;
        }

        public async Task<ClientCategory> GetClientCategory(int id)
        {
            ClientCategory category = await _context.ClientCategories.FindAsync(id);
            return category;
        }

        public async Task<ClientCategory> PostClientCategory(ClientCategory category)
        {
            _context.ClientCategories.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return category;
        }

        public async Task<bool> DeleteClientCategory(ClientCategory category)
        {
            _context.ClientCategories.Remove(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateClientCategory(ClientCategory category)
        {
            _context.ClientCategories.Update(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}