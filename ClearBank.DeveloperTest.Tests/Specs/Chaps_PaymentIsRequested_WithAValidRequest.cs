﻿namespace ClearBank.DeveloperTest.Tests.Specs;

public class Chaps_PaymentIsRequested_WithAValidRequest : GivenSubject<PaymentService, IMakePaymentResult>
{
    public Chaps_PaymentIsRequested_WithAValidRequest()
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
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_CHAPS,
                    PaymentScheme = PaymentScheme.Chaps
                }));
    }

    [Fact]
    public void Then_a_MakePaymentResult_failure_code_is_zero() => Result.FailureCode.Should().Be(0);

    [Fact]
    public void Then_a_MakePaymentResult_is_returned() => Result.Should().NotBeNull();

    [Fact]
    public void Then_the_MakePaymentResult_is_success() => Result.Success.Should().BeTrue();
}