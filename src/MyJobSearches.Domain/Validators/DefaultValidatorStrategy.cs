namespace MyJobSearches.Domain.Validators;

public class DefaultValidatorStrategy<T> : IValidatorStrategy<T>
{
    public bool IsValid(T validateThis)
    {
        var result = Validate(validateThis);
        return result.Count == 0;
    }

    private List<ValidationResult> Validate(T model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model!);

        Validator.TryValidateObject(model!, context, results, true);

        return results;
    }
}

