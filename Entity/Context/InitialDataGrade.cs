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
                Name = "Primaria Infancia (Jardin-transicion)",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradePri = new Grade()
            {
                Id = 2,
                Name = "Primaria",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeBasi = new Grade()
            {
                Id = 3,
                Name = "Basic",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeMedi = new Grade()
            {
                Id = 4,
                Name = "Media",
                State = true,
                Code = "04",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeCle = new Grade()
            {
                Id = 5,
                Name = "CLEI",
                State = true,
                Code = "05",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var GradeAnter = new Grade()
            {
                Id = 6,
                Name = "Todas las anteriores",
                State = true,
                Code = "06",
                CreatedAt = currentDate,
                DeletedAt = null!
            };



            // Registrar los datos en EF Core
            modelBuilder.Entity<Grade>().HasData(
                GradePrimer, GradePri, GradeMedi, GradeBasi, GradeCle, GradeAnter
            );
        }
    }
}

