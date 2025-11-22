using Entity.Models.ModuleOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public  interface IExperienceEditPermissionRepository
    {
        Task<ExperienceEditPermission?> GetByExperienceIdAsync(int experienceId);
        Task AddAsync(ExperienceEditPermission permission);
        Task UpdateAsync(ExperienceEditPermission permission);
        Task<List<ExperienceEditPermission>> GetAllAsync();

    }
}
