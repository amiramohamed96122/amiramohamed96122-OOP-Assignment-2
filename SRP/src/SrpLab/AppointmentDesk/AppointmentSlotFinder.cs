namespace SrpLab;

public sealed class AppointmentSlotFinder
{
    public DateTimeOffset? FindNext(
        AppointmentSchedule schedule,
        DateTimeOffset from,
        int searchHours)
    {
        var cursor = schedule.Align(from);
        var end = from.AddHours(searchHours);

        while (cursor < end)
        {
            if (schedule.IsWithinBusinessHours(cursor) &&
                !schedule.IsBooked(cursor))
            {
                return cursor;
            }

            cursor = cursor.AddMinutes(schedule.SlotMinutes);
        }

        return null;
    }
}