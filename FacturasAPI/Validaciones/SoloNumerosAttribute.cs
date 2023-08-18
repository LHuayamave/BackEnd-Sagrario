using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FacturasAPI.Validaciones
{
    public class SoloNumerosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string valor = value.ToString();

            if (!Regex.IsMatch(valor, @"^[0-9]+$"))
            {
                return new ValidationResult("Solo se permiten números");
            }

            return ValidationResult.Success;
        }
    }
}
