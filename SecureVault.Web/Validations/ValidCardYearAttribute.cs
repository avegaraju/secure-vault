using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecureVault.Web.Validations
{
    public class ValidCardYearAttribute: Attribute, IModelValidator
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var returnValue = value is int parsedValue &&
        //                      parsedValue >= DateTime.Now.Year;

        //    return returnValue == false 
        //        ? new ValidationResult("Expiry year is not valid.") 
        //        : ValidationResult.Success;
        //}

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var returnValue = context.Model is int parsedValue &&
                                  parsedValue >= DateTime.Now.Year;

            return returnValue == false
                ? new List<ModelValidationResult>
                {
                    new ModelValidationResult("", "Year is not valid.")
                }
                : Enumerable.Empty<ModelValidationResult>();
            //? new ValidationResult("Expiry year is not valid.")
            //: ValidationResult.Success;
        }
    }
}
