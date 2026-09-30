namespace SrpLab.KitchenTicket;

public sealed class KitchenTicketItem
{
    public string Item { get; }

    public IReadOnlyList<string> Ingredients { get; }

    public int PrepMinutes { get; }

    public KitchenTicketItem(
        string item,
        IEnumerable<string> ingredients,
        int prepMinutes)
    {
        Item = item;

        Ingredients = ingredients
            .Select(i => i.Trim().ToLowerInvariant())
            .ToList()
            .AsReadOnly();

        PrepMinutes = prepMinutes;
    }
}