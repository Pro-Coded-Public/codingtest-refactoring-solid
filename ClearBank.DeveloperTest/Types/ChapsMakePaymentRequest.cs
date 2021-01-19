
using System;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Types
{
    public class ChapsMakePaymentRequest : MakePaymentRequest
    {
        public override PaymentScheme PaymentScheme => PaymentScheme.Chaps;

        public override ITransactionValidator TransactionValidator => new ChapsTransactionValidator();
    }
}