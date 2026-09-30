namespace SrpLab.KitchenTicket;

/// <summary>
/// Detects allergens from kitchen ticket ingredients.
/// </summary>
public sealed class AllergenDetector
{
    public IReadOnlyList<string> Detect(
        IReadOnlyList<KitchenTicketItem> items)
    {
        var hits =
            new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);

        foreach (var item in items)
        {
            foreach (var ingredient in item.Ingredients)
            {
                if (ingredient.Contains("milk") ||
                    ingredient.Contains("cheese") ||
                    ingredient.Contains("butter"))
                {
                    hits.Add("dairy");
                }

                if (ingredient.Contains("wheat") ||
                    ingredient.Contains("flour") ||
                    ingredient.Contains("bread"))
                {
                    hits.Add("gluten");
                }

                if (ingredient.Contains("peanut") ||
                    ingredient.Contains("almond") ||
                    ingredient.Contains("cashew"))
                {
                    hits.Add("nuts");
                }

                if (ingredient.Contains("shrimp") ||
                    ingredient.Contains("prawn") ||
                    ingredient.Contains("crab"))
                {
                    hits.Add("shellfish");
                }
            }
        }

        return hits
            .OrderBy(x => x)
            .ToList();
    }
}