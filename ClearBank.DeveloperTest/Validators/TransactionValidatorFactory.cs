using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Validators
{
    public static class TransactionValidatorFactory
    {
        public static ITransactionValidator CreateBacsTransactionValidator() { return new BacsTransactionValidator(); }

        public static ITransactionValidator CreateChapsTransactionValidator()
        { return new ChapsTransactionValidator(); }

        public static ITransactionValidator CreateFasterPaymentsTransactionValidator()
        { return new FasterPaymentsTransactionValidator(); }
    }
}
