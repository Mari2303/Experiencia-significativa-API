using Entity.Context;
using Entity.Models.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IModuleOperationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class ExperienceEditPermissionRepository : IExperienceEditPermissionRepository
    {
        private readonly ApplicationContext _context;
        public ExperienceEditPermissionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ExperienceEditPermission?> GetByExperienceIdAsync(int experienceId)
        {
            return await _context.ExperienceEditPermissions
                .FirstOrDefaultAsync(x => x.ExperienceId == experienceId);
        }

        public async Task AddAsync(ExperienceEditPermission permission)
        {
            await _context.ExperienceEditPermissions.AddAsync(permission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExperienceEditPermission permission)
        {
            _context.ExperienceEditPermissions.Update(permission);
            await _context.SaveChangesAsync();
        }





        public async Task<List<ExperienceEditPermission>> GetAllAsync()
        {
            // Validación opcional
            if (_context.ExperienceEditPermissions == null)
                return new List<ExperienceEditPermission>();

            return await _context.ExperienceEditPermissions
                .Include(p => p.User)
                .Include(p => p.Experience)
                .ToListAsync();
        }



    }
}
