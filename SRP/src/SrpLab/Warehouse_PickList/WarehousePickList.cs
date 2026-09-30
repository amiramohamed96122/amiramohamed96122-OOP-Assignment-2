namespace SrpLab.Warehouse_PickList;

/// <summary>
/// Stores warehouse pick-list needs.
/// </summary>
public sealed class WarehousePickList
{
    private readonly List<WarehousePickLine> _lines = new();

    public void AddNeed(
        string sku,
        string aisle,
        int bin,
        int qtyNeeded,
        int qtyOnHand)
    {
        _lines.Add(
            new WarehousePickLine(
                sku,
                aisle,
                bin,
                qtyNeeded,
                qtyOnHand));
    }

    public IReadOnlyList<WarehousePickLine> Lines
    {
        get
        {
            return _lines.AsReadOnly();
        }
    }
}