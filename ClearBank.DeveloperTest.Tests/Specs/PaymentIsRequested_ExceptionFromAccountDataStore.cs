namespace ClearBank.DeveloperTest.Tests.Specs;

public class PaymentIsRequested_ExceptionFromAccountDataStore : GivenSubject<PaymentService, IMakePaymentResult>
{
    public PaymentIsRequested_ExceptionFromAccountDataStore()
    {
        Given(
            () =>
            {
                _ = The<IAccountDataStore>();
                _ = SetThe<ITransactionValidator>().To(TransactionValidatorFactory.CreateBacsTransactionValidator());
            });
        When(
            () => Subject.MakePayment(
                new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_EXCEPTION,
                    PaymentScheme = PaymentScheme.Bacs
                }));
    }

    [Fact]
    public void Then_a_MakePaymentResult_is_returned() => Result.Should().NotBeNull();

    [Fact]
    public void Then_the_MakePaymentResult_code_is_exception() => Result.FailureCode.Should().Be(FailureCodeConstants.EXCEPTION);

    [Fact]
    public void Then_the_MakePaymentResult_is_failure() => Result.Success.Should().BeFalse();
}