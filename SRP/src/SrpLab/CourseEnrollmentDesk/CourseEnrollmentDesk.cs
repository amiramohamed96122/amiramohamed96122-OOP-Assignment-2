namespace SrpLab.CourseEnrollmentDesk;

/// <summary>
/// Coordinates course enrollment, waitlist management,
/// welcome packets, and tuition invoices.
/// </summary>
public sealed class CourseEnrollmentDesk
{
    private readonly CourseEnrollmentRegistry _registry;
    private readonly WelcomePacketFormatter _welcomePacketFormatter = new();
    private readonly TuitionInvoiceFormatter _tuitionInvoiceFormatter = new();

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentDesk(
        string courseCode,
        int capacity,
        decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;

        _registry = new CourseEnrollmentRegistry(capacity);
    }

    public string Register(string studentEmail)
    {
        return _registry.Register(studentEmail);
    }

    public int WaitlistPosition(string studentEmail) => _registry.WaitlistPosition(studentEmail);


    public string WelcomePacketMarkdown(
        string studentEmail,
        string studentName)
    {
        return _welcomePacketFormatter.Format(
            CourseCode,
            studentEmail,
            studentName,
            _registry);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        return _tuitionInvoiceFormatter.Format(
            CourseCode,
            Tuition,
            _registry.IsSeated(studentEmail));
    }

    public void PromoteFromWaitlist(int seats)
    {
        _registry.PromoteFromWaitlist(seats);
    }
}