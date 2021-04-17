using Data.DominiCode.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Domini.Repository
{
    public interface IDominiRepository
    {
        Task<List<ClientCategory>> GetClientCategories();

        Task<ClientCategory> GetClientCategory(int id);

        Task<ClientCategory> PostClientCategory(ClientCategory category);

        Task<bool> DeleteClientCategory(ClientCategory category);

        Task<bool> UpdateClientCategory(ClientCategory category);
    }
}