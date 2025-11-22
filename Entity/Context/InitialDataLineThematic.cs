using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal static class InitialDataLineThematic
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {
            
            // LineThematic
            var lineTech = new LineThematic()
            {
                Id = 1,
                Name = "Ciencia y Tecnología",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var lineEdu = new LineThematic()
            {
                Id = 2,
                Name = "Educación Ambiental",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var lineIntercul = new LineThematic()
            {
                Id = 3,
                Name = "Interculturalidad Bilingüismo",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var lineArt = new LineThematic()
            {
                Id = 4,
                Name = "Arte, Cultura y Patrimonio",
                State = true,
                CreatedAt = currentDate,
                Code = "04",
                DeletedAt = null!
            };
            var lineSkills = new LineThematic()
            {
                Id = 5,
                Name = "Habilidades Comunicativas",
                State = true,
                CreatedAt = currentDate,
                Code = "05",
                DeletedAt = null!
            };
            var lineCurricular = new LineThematic()
            {
                Id = 6,
                Name = "Academica Curricular",
                State = true,
                CreatedAt = currentDate,
                Code = "06",
                DeletedAt = null!
            };

            var lineInclusion = new LineThematic()
            {
                Id = 7,
                Name = "Inclusion Diversidad",
                State = true,
                CreatedAt = currentDate,
                Code = "07",
                DeletedAt = null!
            };

            var lineCoexistence = new LineThematic()
            {
                Id = 8,
                Name = "Convivencia Escolar (Ciencias Sociales y Políticas)",
                State = true,
                CreatedAt = currentDate,
                Code = "08",
                DeletedAt = null!
            };
            var lineDance = new LineThematic()
            {
                Id = 9,
                Name = "Danza, Deporte y Recreación",
                State = true,
                CreatedAt = currentDate,
                Code = "09",
                DeletedAt = null!
            };


            // Registrar los datos en EF Core
            modelBuilder.Entity<LineThematic>().HasData(
                lineTech, lineEdu, lineIntercul, lineArt, lineSkills, lineCurricular, lineInclusion, lineCoexistence, lineDance
            );
        }
    }
}

