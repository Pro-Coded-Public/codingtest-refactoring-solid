﻿using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Services;

public class PaymentService : IPaymentService
{
    private readonly IAccountDataStore _accountDataStore;
    private readonly ITransactionValidator _transactionValidator;

    public PaymentService(IAccountDataStore accountDataStore, ITransactionValidator transactionValidator)
    {
        _transactionValidator = transactionValidator ??
            throw new ArgumentException("transactionValidator cannot be null");
        _accountDataStore = accountDataStore ?? throw new ArgumentException("accountDataStore cannot be null");
    }

    //TODO: This should ideally be async
    public MakePaymentResult MakePayment(MakePaymentRequest request)
    {
        try
        {
            Account account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            if (account == null)
            {
                return MakePaymentResult.FailureResult(FailureCodeConstants.ACCOUNT_NOT_FOUND);
            }

            TransactionValidationResult transactionValidationResult = _transactionValidator.Validate(account, request);

            if (transactionValidationResult.IsValid)
            {
                account.Balance -= request.Amount;
                _accountDataStore.UpdateAccount(account);

                return MakePaymentResult.SuccessResult();
            }
            else
            {
                return MakePaymentResult.FailureResult(transactionValidationResult.ValidationError);
            }
        }
        catch (Exception)
        {
            // Log exception etc, preferably using Serilog / some form of structured logging.
            return MakePaymentResult.FailureResult(FailureCodeConstants.EXCEPTION);
        }
    }
}