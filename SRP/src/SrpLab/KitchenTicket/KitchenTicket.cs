namespace SrpLab.KitchenTicket;

/// <summary>
/// Stores kitchen order items.
/// </summary>
public sealed class KitchenTicket
{
    private readonly List<KitchenTicketItem> _items = new();

    public void AddItem(
        string item,
        IEnumerable<string> ingredients,
        int prepMinutes)
    {
        _items.Add(
            new KitchenTicketItem(
                item,
                ingredients,
                prepMinutes));
    }

    public IReadOnlyList<KitchenTicketItem> Items
    {
        get
        {
            return _items.AsReadOnly();
        }
    }
}