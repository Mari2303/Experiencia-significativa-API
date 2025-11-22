using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal static class InitialDataGrade
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {
            var GradePrimer = new Grade()
            {
                Id = 1,
                Name = "Primaria",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeSecun = new Grade()
            {
                Id = 2,
                Name = "Secundaria",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeMedi = new Grade()
            {
                Id = 3,
                Name = "Media",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            // Registrar los datos en EF Core
            modelBuilder.Entity<Grade>().HasData(
                GradePrimer, GradeSecun, GradeMedi
            );
        }
    }
}
