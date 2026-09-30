using SrpLab.Warehouse_PickList;

public sealed class WarehouseWalkingPlanner
{
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> CreateOrder(
        IReadOnlyList<WarehousePickLine> lines)
    {
        return lines
            .OrderBy(l => l.Aisle)
            .ThenBy(l => l.Bin)
            .Select(l =>
                (
                    l.Aisle,
                    l.Bin,
                    l.Sku,
                    Math.Min(l.QtyNeeded, l.QtyOnHand)
                ))
            .Where(x => x.Item4 > 0)
            .ToList();
    }
}