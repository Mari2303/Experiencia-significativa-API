using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal static class InitialDataPopulationGrade
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {


            var PopulationGradeIndi = new PopulationGrade()
            {
                Id = 1,
                Name = "Indigenas",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradeAfroco = new PopulationGrade()
            {
                Id = 2,
                Name = "Afrocolombianos",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradeMesti = new PopulationGrade()
            {
                Id = 3,
                Name = "Mestizos",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradePalenq = new PopulationGrade()
            {
                Id = 4,
                Name = "Palenqueros",
                State = true,
                Code = "04",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradePeque = new PopulationGrade()
            {
                Id = 5,
                Name = "Pequeños Productores",
                State = true,
                Code = "05",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeRaiza = new PopulationGrade()
            {
                Id = 6,
                Name = "Raizales",
                State = true,
                Code = "06",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeRom = new PopulationGrade()
            {
                Id = 7,
                Name = "Rom",
                State = true,
                Code = "07",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            // Registrar los datos en EF Core
            modelBuilder.Entity<PopulationGrade>().HasData(
                PopulationGradeIndi, PopulationGradeAfroco, PopulationGradeMesti, PopulationGradePalenq, PopulationGradePeque, PopulationGradeRaiza, PopulationGradeRom
            );
        }
    }
}
