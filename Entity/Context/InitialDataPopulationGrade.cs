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
                Name = "Negritudes",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradeAfroco = new PopulationGrade()
            {
                Id = 2,
                Name = "Afrodecendientes",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradeMesti = new PopulationGrade()
            {
                Id = 3,
                Name = "Palanquero",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var PopulationGradePalenq = new PopulationGrade()
            {
                Id = 4,
                Name = "Rizal",
                State = true,
                Code = "04",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradePeque = new PopulationGrade()
            {
                Id = 5,
                Name = "Rom/Gitano",
                State = true,
                Code = "05",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeRaiza = new PopulationGrade()
            {
                Id = 6,
                Name = "Victima del conficto",
                State = true,
                Code = "06",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeRom = new PopulationGrade()
            {
                Id = 7,
                Name = "Diacapacidad",
                State = true,
                Code = "07",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeTale = new PopulationGrade()
            {
                Id = 8,
                Name = "Talentos Excepcionales",
                State = true,
                Code = "08",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeInd = new PopulationGrade()
            {
                Id = 9,
                Name = "Indigena",
                State = true,
                Code = "09",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeTras = new PopulationGrade()
            {
                Id = 10,
                Name = "Trastornos Especificos",
                State = true,
                Code = "10",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var PopulationGradeNin = new PopulationGrade()
            {
                Id = 11,
                Name = "Ninguna de las anteriores",
                State = true,
                Code = "11",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            // Registrar los datos en EF Core
            modelBuilder.Entity<PopulationGrade>().HasData(
                PopulationGradeIndi, PopulationGradeAfroco, PopulationGradeMesti, PopulationGradePalenq, PopulationGradePeque, PopulationGradeRaiza, PopulationGradeRom, PopulationGradeTale, PopulationGradeInd, PopulationGradeTras, PopulationGradeNin
            );
        }
    }
}