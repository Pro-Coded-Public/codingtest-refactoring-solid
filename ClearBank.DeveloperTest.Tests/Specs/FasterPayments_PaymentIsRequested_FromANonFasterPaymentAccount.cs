namespace ClearBank.DeveloperTest.Tests.Specs;

public class FasterPayments_PaymentIsRequested_FromANonFasterPaymentAccount : GivenSubject<PaymentService, IMakePaymentResult>
{
    public FasterPayments_PaymentIsRequested_FromANonFasterPaymentAccount()
    {
        Given(
            () =>
            {
                _ = The<IAccountDataStore>();
                _ = SetThe<ITransactionValidator>()
                    .To(TransactionValidatorFactory.CreateFasterPaymentsTransactionValidator());
            });
        When(
            () => Subject.MakePayment(
                new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_BACS,
                    PaymentScheme = PaymentScheme.FasterPayments
                }));
    }

    [Fact]
    public void Then_a_MakePaymentResult_is_returned() => Result.Should().NotBeNull();

    [Fact]
    public void Then_the_MakePaymentResult_code_is_unsupported_payment_scheme() => Result.FailureCode.Should().Be(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);

    [Fact]
    public void Then_the_MakePaymentResult_is_failure() => Result.Success.Should().BeFalse();
}