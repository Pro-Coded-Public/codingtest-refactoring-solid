using ClearBank.DeveloperTest.Constants;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class ChapsTransactionValidator : ITransactionValidator
    {
        public TransactionValidationResult Validate(Account account, MakePaymentRequest request)
        {
            if((account.AllowedPaymentSchemes & AllowedPaymentSchemes.Chaps) == 0)
            {
                return TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);
            }

            if(account.Status != AccountStatus.Live)
            {
                return TransactionValidationResult.FailureResult(FailureCodeConstants.ACCOUNT_NOT_LIVE);
            }

            return TransactionValidationResult.SuccessResult();
        }
    }
}