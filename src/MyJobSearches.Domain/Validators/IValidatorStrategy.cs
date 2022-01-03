namespace MyJobSearches.Domain.Validators;

public interface IValidatorStrategy<T>
{
    bool IsValid(T validateThis);
}

