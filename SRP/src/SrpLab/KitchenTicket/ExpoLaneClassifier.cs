namespace SrpLab.KitchenTicket;

/// <summary>
/// Selects the expo lane for a kitchen order.
/// </summary>
public sealed class ExpoLaneClassifier
{
    public string GetLane(
        int allergenCount,
        int estimatedReadyMinutes)
    {
        if (allergenCount > 0)
        {
            return "LANE-ALLERGY";
        }

        if (estimatedReadyMinutes > 20)
        {
            return "LANE-SLOW";
        }

        return "LANE-FAST";
    }
}