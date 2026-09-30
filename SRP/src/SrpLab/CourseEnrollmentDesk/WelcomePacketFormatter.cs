namespace SrpLab.CourseEnrollmentDesk;

public sealed class WelcomePacketFormatter
{
    public string Format(
        string courseCode,
        string studentEmail,
        string studentName,
        CourseEnrollmentRegistry registry)
    {
        var status = registry.IsSeated(studentEmail)
            ? "confirmed seat"
            : $"waitlist #{registry.WaitlistPosition(studentEmail)}";

        return $"# Welcome to {courseCode}\n" +
               $"Hi {studentName},\n" +
               $"Your status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: " +
               $"https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}