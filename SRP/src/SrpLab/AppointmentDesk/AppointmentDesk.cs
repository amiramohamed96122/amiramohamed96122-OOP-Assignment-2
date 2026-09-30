namespace SrpLab;

/// <summary>
/// Coordinates appointment scheduling, calendar generation,
/// and SMS reminder creation through focused components.
/// </summary>
public sealed class AppointmentDesk
{
    private readonly AppointmentSchedule _schedule;
    private readonly AppointmentSlotFinder _slotFinder = new();
    private readonly IcsCalendarFormatter _icsFormatter = new();
    private readonly SmsReminderFormatter _smsFormatter = new();

    public TimeOnly Open => _schedule.Open;
    public TimeOnly Close => _schedule.Close;
    public int SlotMinutes => _schedule.SlotMinutes;

    public AppointmentDesk(
        TimeOnly open,
        TimeOnly close,
        int slotMinutes)
    {
        _schedule = new AppointmentSchedule(
            open,
            close,
            slotMinutes);
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        return _schedule.IsWithinBusinessHours(when);
    }

    public DateTimeOffset? FindNextSlot(
        DateTimeOffset from,
        int searchHours)
    {
        return _slotFinder.FindNext(
            _schedule,
            from,
            searchHours);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        return _schedule.TryBook(slot);
    }

    public string ToIcs(
        DateTimeOffset slot,
        string patientName,
        string clinician)
    {
        return _icsFormatter.Format(
            slot,
            SlotMinutes,
            patientName,
            clinician);
    }

    public string SmsReminder(  DateTimeOffset slot, string clinicPhone)
    {
        return _smsFormatter.Format( slot,   clinicPhone);
    }
}