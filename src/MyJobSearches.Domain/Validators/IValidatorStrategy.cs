namespace MyJobSearches.Domain.Validators;

public interface IValidatorStrategy<in T>
{
    bool IsValid(T validateThis);
}

