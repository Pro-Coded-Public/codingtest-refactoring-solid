namespace ClearBank.DeveloperTest.Validators;

public class FasterPaymentsTransactionValidator : ITransactionValidator
{
    public TransactionValidationResult Validate(Account account, MakePaymentRequest request)
    {
        if ((account.AllowedPaymentSchemes & AllowedPaymentSchemes.FasterPayments) == 0)
        {
            return TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);
        }

        return request.Amount >= account.Balance
            ? TransactionValidationResult.FailureResult(FailureCodeConstants.INSUFFICIENT_FUNDS)
            : TransactionValidationResult.SuccessResult();
    }
}