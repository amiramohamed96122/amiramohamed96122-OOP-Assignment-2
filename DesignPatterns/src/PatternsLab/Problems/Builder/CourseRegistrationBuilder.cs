
namespace PatternsLab.Problems.Builder; 

public sealed class CourseRegistrationBuilder
{
    private string? _studentEmail;
    private string? _courseCode;
    private string? _accessMode;
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;

    public CourseRegistrationBuilder ForStudent(string studentEmail)
    {
        _studentEmail = studentEmail;
        return this;
    }

    public CourseRegistrationBuilder ForCourse(string courseCode)
    {
        _courseCode = courseCode;
        return this;
    }

    public CourseRegistrationBuilder LiveGroup(string groupCode)
    {
        _accessMode = "LiveGroup";
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder VideosOnly()
    {
        _accessMode = "VideosOnly";
        _groupCode = null;
        return this;
    }

    public CourseRegistrationBuilder WithDiscount(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder SendWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string mentorNote)
    {
        _mentorNote = mentorNote;
        return this;
    }

    public CourseRegistrationBuilder StartingOn(DateOnly preferredStart)
    {
        _preferredStart = preferredStart;
        return this;
    }

    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail))
            throw new InvalidOperationException("Student email is required.");

        if (string.IsNullOrWhiteSpace(_courseCode))
            throw new InvalidOperationException("Course code is required.");

        if (string.IsNullOrWhiteSpace(_accessMode))
            throw new InvalidOperationException("Access mode is required.");

        if (_accessMode == "LiveGroup" &&   string.IsNullOrWhiteSpace(_groupCode))
        {
            throw new InvalidOperationException( "LiveGroup requires GroupCode.");
        }

        if (_accessMode == "VideosOnly" &&  !string.IsNullOrWhiteSpace(_groupCode))
        {
            throw new InvalidOperationException( "VideosOnly cannot have GroupCode.");
        }

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart);
    }
}
    
