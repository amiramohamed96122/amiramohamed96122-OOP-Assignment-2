namespace SrpLab;

public sealed class IcsCalendarFormatter
{
    public string Format(
        DateTimeOffset slot,
        int slotMinutes,
        string patientName,
        string clinician)
    {
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(slotMinutes);

        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\n" +
               $"DTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"DTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\n" +
               "END:VEVENT\n" +
               "END:VCALENDAR\n";
    }
}