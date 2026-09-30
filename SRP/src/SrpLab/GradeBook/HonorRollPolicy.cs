namespace SrpLab.GradeBook;

/// <summary>
/// Applies honor-roll eligibility rules.
/// </summary>
public sealed class HonorRollPolicy
{
    public bool MeetsHonorRoll(decimal average, string letter)
    {
        return average >= 85 &&
               (letter == "A" || letter == "B");
    }
}