namespace ClearBank.DeveloperTest.Validators;

public static class TransactionValidatorFactory
{
    public static ITransactionValidator CreateBacsTransactionValidator() => new BacsTransactionValidator();

    public static ITransactionValidator CreateChapsTransactionValidator() => new ChapsTransactionValidator();

    public static ITransactionValidator CreateFasterPaymentsTransactionValidator() => new FasterPaymentsTransactionValidator();
}
