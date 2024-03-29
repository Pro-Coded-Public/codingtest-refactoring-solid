﻿namespace ClearBank.DeveloperTest.Tests.Specs
{
    public class FasterPayments_PaymentIsRequested_WithAValidRequest : GivenSubject<PaymentService, IMakePaymentResult>
    {
        public FasterPayments_PaymentIsRequested_WithAValidRequest()
        {
            Given(
                () =>
                {
                    The<IAccountDataStore>();
                    SetThe<ITransactionValidator>()
                        .To(TransactionValidatorFactory.CreateFasterPaymentsTransactionValidator());
                });

            When(
                () => Subject.MakePayment(
                    new MakePaymentRequest
                    {
                        DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS,
                        PaymentScheme = PaymentScheme.FasterPayments,
                        Amount = 1
                    }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_failure_code_is_zero() { Result.FailureCode.Should().Be(0); }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_is_success() { Result.Success.Should().BeTrue(); }
    }
}