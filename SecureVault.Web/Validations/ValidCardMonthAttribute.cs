using System;
using System.ComponentModel.DataAnnotations;

namespace SecureVault.Web.Validations
{
    public class ValidCardMonthAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is int parsedValue &&
                   parsedValue > 0 &&
                   parsedValue <= 12;
        }
    }
}
