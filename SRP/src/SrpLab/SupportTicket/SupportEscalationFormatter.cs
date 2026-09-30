namespace SrpLab.SupportTicket;

/// <summary>
/// Formats internal support escalation information.
/// </summary>
public sealed class SupportEscalationFormatter
{
    public string Format(
        SupportTicket ticket,
        DateTimeOffset slaDeadline)
    {
        return
            $"ESCALATE {ticket.Id} " +
            $"priority={ticket.Priority} " +
            $"breachAt={slaDeadline:u} " +
            $"keywords-scanned=yes";
    }
}