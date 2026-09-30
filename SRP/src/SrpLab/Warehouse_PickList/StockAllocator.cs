namespace SrpLab.Warehouse_PickList;

public sealed class StockAllocator
{
    public IReadOnlyList<(string Sku, int Allocated)> Allocate(
        IReadOnlyList<WarehousePickLine> lines)
    {
        var result = new List<(string, int)>();

        foreach (var line in lines)
        {
            int allocated = Math.Min(
                line.QtyNeeded,
                line.QtyOnHand);

            result.Add(
                (line.Sku, allocated));
        }

        return result;
    }
}