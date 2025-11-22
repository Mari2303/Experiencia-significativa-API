using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal static class InitialDataState
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {

            
            var StateRising = new StateExperience()
            {
                Id = 1,
                Name = "Naciente",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var StateGrowing = new StateExperience()
            {
                Id = 2,
                Name = "Creciente",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var StateInspirational = new StateExperience()
            {
                Id = 3,
                Name = "Inspiradora",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            // Registrar los datos en EF Core
            modelBuilder.Entity<StateExperience>().HasData(
                StateRising, StateGrowing, StateInspirational
            );
        }
    }
}

