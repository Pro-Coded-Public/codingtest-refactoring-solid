namespace ClearBank.DeveloperTest.Tests.Specs;

public class Chaps_PaymentIsRequested_FromANonChapsAccount : GivenSubject<PaymentService, IMakePaymentResult>
{
    public Chaps_PaymentIsRequested_FromANonChapsAccount()
    {
        Given(
            () =>
            {
                _ = The<IAccountDataStore>();
                _ = SetThe<ITransactionValidator>().To(TransactionValidatorFactory.CreateChapsTransactionValidator());
            });
        When(
            () => Subject.MakePayment(
                new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS,
                    PaymentScheme = PaymentScheme.Chaps
                }));
    }

    [Fact]
    public void Then_a_MakePaymentResult_is_returned() => Result.Should().NotBeNull();

    [Fact]
    public void Then_the_MakePaymentResult_code_is_unsupported_payment_scheme() => Result.FailureCode.Should().Be(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);

    [Fact]
    public void Then_the_MakePaymentResult_is_failure() => Result.Success.Should().BeFalse();
}