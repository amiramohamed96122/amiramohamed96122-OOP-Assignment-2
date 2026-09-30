namespace SrpLab.GradeBook;

/// <summary>
/// Applies academic letter-grade rules.
/// </summary>
public sealed class GradePolicy
{
    public string Letter(decimal average)
    {
        if (average >= 90)
        {
            return "A";
        }

        if (average >= 80)
        {
            return "B";
        }

        if (average >= 70)
        {
            return "C";
        }

        if (average >= 60)
        {
            return "D";
        }

        return "F";
    }
}