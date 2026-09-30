namespace SrpLab.SubscriptionBilling;

/// <summary>
/// Generates subscription invoice numbers.
/// </summary>
public sealed class InvoiceNumberGenerator
{
    private static int _invoiceSeq = 1000;

    public string NextInvoiceNumber(
        SubscriptionBilling subscription)
    {
        var number = ++_invoiceSeq;

        return
            $"INV-{subscription.PeriodStart:yyyyMM}-{number:D5}";
    }
}