namespace SrpLab.SupportTicket;

/// <summary>
/// Generates public customer reply messages.
/// </summary>
public sealed class SupportReplyGenerator
{
    public string Generate(
        SupportTicket ticket,
        string agentName,
        DateTimeOffset slaDeadline)
    {
        string apology;

        if (ticket.Priority == "P1")
        {
            apology =
                "We are treating this as a critical incident.";
        }
        else
        {
            apology =
                "Thanks for reaching out.";
        }

        return
            $"Hi,\n" +
            $"{apology}\n" +
            $"Ticket {ticket.Id} is with {agentName}. " +
            $"Next update before {slaDeadline:u}.\n";
    }
}