namespace SrpLab.SupportTicket;

/// <summary>
/// Calculates support SLA deadlines and breach status.
/// </summary>
public sealed class SupportSlaCalculator
{
    public DateTimeOffset SlaDeadline(
        DateTimeOffset openedAt,
        string priority)
    {
        int hours;

        if (priority == "P1")
        {
            hours = 4;
        }
        else if (priority == "P2")
        {
            hours = 24;
        }
        else
        {
            hours = 72;
        }

        return openedAt.AddHours(hours);
    }

    public bool IsBreached(
        DateTimeOffset now,
        DateTimeOffset deadline)
    {
        return now > deadline;
    }
}