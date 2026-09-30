using SrpLab.Warehouse_PickList;

public sealed class PickerScriptGenerator
{
    public string Generate(
        IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> walkingOrder,
        IReadOnlyList<(string Sku, int Allocated)> allocations,
        IReadOnlyList<WarehousePickLine> lines)
    {
        var steps = walkingOrder
            .Select((s, i) =>
                $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");

        var shortfalls = allocations
            .Where(a =>
            {
                var need = lines
                    .First(l => l.Sku == a.Sku)
                    .QtyNeeded;

                return a.Allocated < need;
            });

        var warning = shortfalls.Any()
            ? "SHORTAGES: " +
              string.Join(", ", shortfalls.Select(s => s.Sku))
            : "SHORTAGES: none";

        return string.Join('\n', steps)
               + "\n"
               + warning;
    }
}