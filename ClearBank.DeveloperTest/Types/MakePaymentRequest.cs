using System;

namespace ClearBank.DeveloperTest.Types;

public class MakePaymentRequest
{
    public decimal Amount { get; set; }

    public string CreditorAccountNumber { get; set; }

    public string DebtorAccountNumber { get; set; }

    public DateTime PaymentDate { get; set; }

    public PaymentScheme PaymentScheme { get; set; }
}