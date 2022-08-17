namespace ClearBank.DeveloperTest.Validators;

public class TransactionValidationResult
{
    public static TransactionValidationResult FailureResult(int validationError) => new() { IsValid = false, ValidationError = validationError };

    public static TransactionValidationResult SuccessResult() => new()
    {
        IsValid = true
    };

    public bool IsValid { get; private set; }

    public int ValidationError { get; private set; }
}