using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IWorkService
    {
        Task<IList<Work>> GetAll();
        Task<Work> GetOne(int workId);
        Task Update(Work work);
        Task Add(Work work);
        Task Delete(int workId);
    }
}
