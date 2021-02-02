﻿using Chill;

using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.Constants;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

using FluentAssertions;

using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specs
{
    public class Chaps_PaymentIsRequested_WithAValidRequest : GivenSubject<PaymentService, IMakePaymentResult>
    {
        public Chaps_PaymentIsRequested_WithAValidRequest()
        {
            Given(
                () =>
                {
                    The<IAccountDataStore>();
                    SetThe<ITransactionValidator>().To(TransactionValidatorFactory.CreateChapsTransactionValidator());
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
        public void Then_a_MakePaymentResult_failure_code_is_zero() { Result.FailureCode.Should().Be(0); }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_is_success() { Result.Success.Should().BeTrue(); }
    }
}