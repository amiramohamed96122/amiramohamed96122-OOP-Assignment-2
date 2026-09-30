namespace SrpLab.SubscriptionBilling;

/// <summary>
/// Generates dunning email messages for failed payments.
/// </summary>
public sealed class DunningEmailGenerator
{
    private readonly SubscriptionProrationCalculator _prorationCalculator =
        new();

    private readonly InvoiceNumberGenerator _invoiceNumberGenerator =
        new();

    public string Generate(
        SubscriptionBilling subscription,
        string customerName,
        DateOnly asOf)
    {
        var amount =
            _prorationCalculator.Prorate(
                subscription,
                subscription.PeriodStart);

        var invoice =
            _invoiceNumberGenerator.NextInvoiceNumber(
                subscription);

        string severity;

        if (subscription.FailedPayments <= 1)
        {
            severity = "friendly reminder";
        }
        else if (subscription.FailedPayments == 2)
        {
            severity = "second notice";
        }
        else
        {
            severity = "final notice before suspension";
        }

        return
            $"Subject: {severity} {invoice}\n" +
            $"Hi {customerName},\n" +
            $"Balance {amount:C} as of {asOf:o} " +
            $"({subscription.FailedPayments} failures).\n";
    }
}