using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal static class InitialDataCriteria   
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {


            var CriteriaRelevance = new Criteria()
            {
                Id = 1,
                Name = "Pertinencia",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var CriteriaRationale = new Criteria()
            {
                Id = 2,
                Name = "Fundamentación",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var CriteriaInnovation = new Criteria()
            {
                Id = 3,
                Name = "Innovación",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var CriteriaResults = new Criteria()
            {
                Id = 4,
                Name = "Resultados",
                State = true,
                Code = "04",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var CriteriaEmpowerment = new Criteria()
            {
                Id = 5,
                Name = "Empoderamiento",
                State = true,
                Code = "05",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var CriteriaFollow = new Criteria()
            {
                Id = 6,
                Name = "Seguimiento y valoración",
                State = true,
                Code = "06",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var CriteriaTransformation = new Criteria()
            {
                Id = 7,
                Name = "Transformación",
                State = true,
                Code = "07",
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var CriteriaSustainability = new Criteria()
            {
                Id = 8,
                Name = "Sostenibilidad",
                State = true,
                Code = "08",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var CriteriaTransfer = new Criteria()
            {
                Id = 9,
                Name = "Transferencia",
                State = true,
                Code = "09",
                CreatedAt = currentDate,
                DeletedAt = null!
            };


            // Registrar los datos en EF Core
            modelBuilder.Entity<Criteria>().HasData(
                CriteriaRelevance, CriteriaRationale, CriteriaInnovation, CriteriaResults, CriteriaEmpowerment, CriteriaFollow, CriteriaTransformation, CriteriaSustainability, CriteriaTransfer
            );
        }
    }
}
