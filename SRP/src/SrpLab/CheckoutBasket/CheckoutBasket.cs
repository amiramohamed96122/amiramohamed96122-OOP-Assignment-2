namespace SrpLab;

/// <summary>
/// Coordinates the checkout basket operations using focused components.
/// </summary>
public sealed class CheckoutBasket
{
    private readonly BasketItems _basketItems = new();
    private readonly CouponDiscountCalculator _couponCalculator = new();
    private readonly CheckoutTotalCalculator _totalCalculator = new();
    private readonly GiftMessageCardFormatter _giftMessageFormatter = new();
    private readonly PaymentAuthorizationGenerator _paymentAuthorizationGenerator = new();

    private string? _couponRaw;
    private bool _giftWrap;

    public void AddLine(string sku, decimal price, int qty)
    {
        _basketItems.Add(sku, price, qty);
    }

    public void ApplyCouponText(string? couponText) =>   _couponRaw = couponText;
    
    public void EnableGiftWrap() => _giftWrap = true;
   
    public decimal SubTotal()
    {
        return _basketItems.SubTotal();
    }

    public decimal DiscountAmount()
    {
        return _couponCalculator.Calculate(
            _couponRaw,
            SubTotal());
    }

    public decimal GrandTotal()
    {
        return _totalCalculator.Calculate( SubTotal(), DiscountAmount(),  _giftWrap );
    }

    public string GiftMessageCard(string fromName)
    {
        return _giftMessageFormatter.Format(
            fromName,
            _basketItems.GetSkus(),
            GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentAuthorizationGenerator.Generate(
            GrandTotal(),
            cardLast4,
            _basketItems.Count);
    }
}