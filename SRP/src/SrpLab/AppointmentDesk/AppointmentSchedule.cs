namespace SrpLab;

public sealed class AppointmentSchedule
{
    private readonly HashSet<DateTimeOffset> _booked = new();

    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }

    public AppointmentSchedule(
        TimeOnly open,
        TimeOnly close,
        int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday)
            return false;

        var t = TimeOnly.FromDateTime(when.DateTime);

        return t >= Open &&
               t.AddMinutes(SlotMinutes) <= Close;
    }

    public bool IsBooked(DateTimeOffset slot)
    {
        return _booked.Contains(slot);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!IsWithinBusinessHours(slot) || _booked.Contains(slot))
            return false;

        _booked.Add(slot);
        return true;
    }

    public DateTimeOffset Align(DateTimeOffset from)
    {
        var minutes =
            from.Minute - (from.Minute % SlotMinutes);

        return new DateTimeOffset(
            from.Year,
            from.Month,
            from.Day,
            from.Hour,
            minutes,
            0,
            from.Offset);
    }
}