namespace ClearBank.DeveloperTest.Validators;

public interface ITransactionValidator
{
    TransactionValidationResult Validate(Account account, MakePaymentRequest request);
}