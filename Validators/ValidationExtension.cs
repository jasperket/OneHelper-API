using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OneHelper.Validators
{
    public static class ValidationExtension
    {
        public static void AddToModelState( this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach ( var item in result.Errors)
            {
                modelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
    }
}
