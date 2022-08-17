namespace ClearBank.DeveloperTest.Validators;

public class ChapsTransactionValidator : ITransactionValidator
{
    public TransactionValidationResult Validate(Account account, MakePaymentRequest request) => (account.AllowedPaymentSchemes & AllowedPaymentSchemes.Chaps) == 0
            ? TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME)
            : account.Status != AccountStatus.Live
            ? TransactionValidationResult.FailureResult(FailureCodeConstants.ACCOUNT_NOT_LIVE)
            : TransactionValidationResult.SuccessResult();
}