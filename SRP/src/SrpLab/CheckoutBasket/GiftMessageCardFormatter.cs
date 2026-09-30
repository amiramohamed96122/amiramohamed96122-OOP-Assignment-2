namespace SrpLab;

public sealed class GiftMessageCardFormatter
{
    public string Format(
        string fromName,
        IEnumerable<string> skus,
        decimal grandTotal)
    {
        var items = string.Join(", ", skus);

        return $"Dear friend,\n" +
               $"A gift from {fromName} awaits ({items}).\n" +
               $"Total surprise value: {grandTotal:C}\n";
    }
}