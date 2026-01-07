using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Domain;

namespace WeddingHall.Application.Interfaces.Repositories
{
    
    public interface IHallRepository : IGenericRepository<HallMaster>
    {
        Task<IEnumerable<HallMaster>> GetAllWithDetailsAsync();
        Task<HallMaster?> GetByIdWithDetailsAsync(Guid id);

    }
}
