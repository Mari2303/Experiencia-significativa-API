using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Entity.Enums;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Helper.Implementation
{
    public  class PersonValidatorHelper
    {
        // Método principal de validación
        public static void Validate(UserRegisterRequest request)
        {
            // Validar DocumentType
            if (!Enum.TryParse<DocumentType>(request.DocumentType, out _))
                throw new Exception("DocumentType inválido");

            // Validar nombres y apellidos (solo letras y espacios)
            ValidateTextField(request.FirstName, "Primer nombre");
            ValidateTextField(request.MiddleName, "Segundo nombre");
            ValidateTextField(request.FirstLastName, "Primer apellido");
            ValidateTextField(request.SecondLastName, "Segundo apellido");
           

            // Validar IdentificationNumber y CodeDane (solo números)
            ValidateNumberField(request.IdentificationNumber, "Número de identificación");
            ValidateNumberField(request.CodeDane, "Código DANE");

            // Validar Phone (ya es uint, solo números)
            if (request.Phone <= 0)
                throw new Exception("El teléfono debe ser un número válido");

            // Validar correos electrónicos
            ValidateEmail(request.Email, "Correo personal");
            ValidateEmail(request.EmailInstitutional, "Correo institucional");
        }




        private static void ValidateTextField(string? value, string fieldName)
        {
            if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
            {
                throw new Exception($"{fieldName} no puede contener números ni caracteres especiales");
            }
        }



        private static void ValidateNumberField(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^\d+$"))
            {
                throw new Exception($"{fieldName} debe contener solo números");
            }
        }




        private static void ValidateEmail(string value, string fieldName)
        {
            if (!string.IsNullOrEmpty(value) && !new EmailAddressAttribute().IsValid(value))
            {
                throw new Exception($"{fieldName} no tiene un formato válido");
            }
        }
    }
}

