namespace SrpLab.KitchenTicket;

/// <summary>
/// Calculates estimated kitchen ready time.
/// </summary>
public sealed class KitchenReadyTimeEstimator
{
    public int Estimate(
        IReadOnlyList<KitchenTicketItem> items,
        int openStations,
        int allergenCount)
    {
        if (openStations <= 0)
        {
            openStations = 1;
        }

        var sequential =
            items.Sum(i => i.PrepMinutes);

        var parallel =
            (int)Math.Ceiling(
                sequential / (double)openStations);

        if (allergenCount > 0)
        {
            parallel += 3;
        }

        var longest =
            items.Count == 0
                ? 0
                : items.Max(i => i.PrepMinutes);

        return Math.Max(
            parallel,
            longest);
    }
}