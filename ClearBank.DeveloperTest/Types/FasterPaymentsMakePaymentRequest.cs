
using System;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Types
{
    public class FasterPaymentsMakePaymentRequest : MakePaymentRequest
    {
        public override PaymentScheme PaymentScheme => PaymentScheme.FasterPayments;

        public override ITransactionValidator TransactionValidator => new FasterPaymentsTransactionValidator();
    }
}