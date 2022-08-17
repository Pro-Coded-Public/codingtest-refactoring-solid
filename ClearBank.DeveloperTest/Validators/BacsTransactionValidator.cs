namespace ClearBank.DeveloperTest.Validators;

public class BacsTransactionValidator : ITransactionValidator
{
    public TransactionValidationResult Validate(Account account, MakePaymentRequest request) => (account.AllowedPaymentSchemes & AllowedPaymentSchemes.Bacs) == 0
            ? TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME)
            : TransactionValidationResult.SuccessResult();
}