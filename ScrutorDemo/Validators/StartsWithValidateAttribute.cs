using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ScrutorDemo.Validators
{
    public class StartsWithValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && !string.IsNullOrWhiteSpace(str))
            {
                if (char.IsUpper(str[0]))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("It is not Upper word");
            }
            return ValidationResult.Success;
        }
    }
}
