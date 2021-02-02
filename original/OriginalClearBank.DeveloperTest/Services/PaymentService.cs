using System.Configuration;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;

namespace OriginalClearBank.DeveloperTest.Services
{
    // S Multiple responsibilities in class - violation of Single Responsibility Principal.
    // O Violation of Open-Closed Principal - it is not possible to extend this class, only to modify it.
    // L No direct violations of Liskov Substitution Principal (objects of Type T may be replaced by objects of a subtype of T), but this is implemented later in the refactored solution.
    // I No direct violations of Interface Segregation Principal; this is followed in the refactored solution.
    // D Violation of Dependency Inversion Principal - high level modules should not depend on low level modules (e.g. AccountDataStore) - they should depend on abstractions.

    // Incorrect logic (core purpose will never be fulfilled)
    // Not possible to test in a coherent manner, if at all.
    // No exception handling.
    public class PaymentService : IPaymentService
    {
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            // Configuration, if absolutely necessary, should be passed in using Options pattern, but ideally refactored to be unnecessary due to dependency injection.
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            Account account = null;

            // Unnecessary, should be passed in via dependency injection (violation of Dependency Inversion Principal)
            if(dataStoreType == "Backup")
            {
                var accountDataStore = new BackupAccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            } else
            {
                var accountDataStore = new AccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            }

            // Instantiation of an instance that may not be used (account may be null, has not yet been verified)
            var result = new MakePaymentResult();

            // Switch statement
            // - repetition of null check
            // - setting a boolean default value (false)
            // - hard-coded validation
            // - poor readilbility
            switch(request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    if(account == null)
                    {
                        result.Success = false;
                    } else if(!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:
                    if(account == null)
                    {
                        result.Success = false;
                    } else if(!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                    {
                        result.Success = false;
                    } else if(account.Balance < request.Amount)
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.Chaps:
                    if(account == null)
                    {
                        result.Success = false;
                    } else if(!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                    {
                        result.Success = false;
                    } else if(account.Status != AccountStatus.Live)
                    {
                        result.Success = false;
                    }
                    break;
            }

            // Incorrect logic - result.Success is always false.
            if(result.Success)
            {
                account.Balance -= request.Amount;

                // Again, not required, should be passed in via dependency injection
                if(dataStoreType == "Backup")
                {
                    var accountDataStore = new BackupAccountDataStore();
                    accountDataStore.UpdateAccount(account);
                } else
                {
                    var accountDataStore = new AccountDataStore();
                    accountDataStore.UpdateAccount(account);
                }
            }

            return result;
        }
    }
}
