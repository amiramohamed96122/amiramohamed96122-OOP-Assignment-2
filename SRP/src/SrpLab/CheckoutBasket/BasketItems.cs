namespace SrpLab;

public sealed class BasketItems
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();

    public void Add(string sku, decimal price, int qty)
    {
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty));

        _lines.Add((sku, price, qty));
    }

    public decimal SubTotal()
    {
        return _lines.Sum(l => l.Price * l.Qty);
    }

    public int Count => _lines.Count;

    public IEnumerable<string> GetSkus()
    {
        return _lines.Select(l => l.Sku);
    }
}