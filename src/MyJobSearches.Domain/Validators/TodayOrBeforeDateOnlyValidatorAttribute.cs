
namespace MyJobSearches.Domain.Models
{
    internal class TodayOrBeforeDateOnlyValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value?.GetType() == typeof(DateOnly))
            {
                var date = (DateOnly)value;
                if (date > DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult("The date cannot be in the future");
                }
            }

            return ValidationResult.Success;
        }
    }
}