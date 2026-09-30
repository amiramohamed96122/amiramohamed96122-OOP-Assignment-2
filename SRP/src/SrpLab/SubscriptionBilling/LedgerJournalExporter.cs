namespace SrpLab.SubscriptionBilling;

/// <summary>
/// Exports subscription billing information as a ledger journal line.
/// </summary>
public sealed class LedgerJournalExporter
{
    private readonly SubscriptionProrationCalculator _prorationCalculator =
        new();

    private readonly InvoiceNumberGenerator _invoiceNumberGenerator =
        new();

    public string Export(
        SubscriptionBilling subscription,
        DateOnly activeFrom)
    {
        var invoice =
            _invoiceNumberGenerator.NextInvoiceNumber(
                subscription);

        var amount =
            _prorationCalculator.Prorate(
                subscription,
                activeFrom);

        return
            $"{subscription.CustomerId}," +
            $"{invoice}," +
            $"{amount:0.00}," +
            "AR-SUB";
    }
}