using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Validations
{
    public class FirstLetterUpperAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is null || value.ToString().IsNullOrEmpty())
            {
                return ValidationResult.Success;
            }

            var valueString = value.ToString()!;
            var firstChar = valueString[0].ToString();

            if (firstChar != firstChar.ToUpper())
            {
                return new ValidationResult("First char must be capital letter");
            }

            return ValidationResult.Success;
        }
    }
}
