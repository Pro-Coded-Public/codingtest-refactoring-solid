
using System;

using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Types
{
    public class BacsMakePaymentRequest : MakePaymentRequest
    {
        public override PaymentScheme PaymentScheme => PaymentScheme.Bacs;

        public override ITransactionValidator TransactionValidator => new BacsTransactionValidator();
    }
}