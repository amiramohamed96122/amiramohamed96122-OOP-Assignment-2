namespace SrpLab.SubscriptionBilling;

/// <summary>
/// Calculates prorated subscription amounts.
/// </summary>
public sealed class SubscriptionProrationCalculator
{
    public decimal Prorate(
        SubscriptionBilling subscription,
        DateOnly activeFrom)
    {
        if (activeFrom <= subscription.PeriodStart)
        {
            return subscription.MonthlyPrice;
        }

        if (activeFrom >= subscription.PeriodEnd)
        {
            return 0m;
        }

        var totalDays =
            subscription.PeriodEnd.DayNumber -
            subscription.PeriodStart.DayNumber;

        if (totalDays <= 0)
        {
            return subscription.MonthlyPrice;
        }

        var used =
            subscription.PeriodEnd.DayNumber -
            activeFrom.DayNumber;

        return Math.Round(
            subscription.MonthlyPrice * used / totalDays,
            2);
    }
}