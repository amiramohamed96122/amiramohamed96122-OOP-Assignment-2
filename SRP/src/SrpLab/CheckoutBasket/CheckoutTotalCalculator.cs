namespace SrpLab;

public sealed class CheckoutTotalCalculator
{
    private const decimal GiftWrapFee = 4.99m;

    public decimal Calculate( decimal subtotal, decimal discount,  bool giftWrap)
    {
        var total = subtotal - discount;

        if (giftWrap)
            total += GiftWrapFee;

        return Math.Max(0m, total);
    }
}