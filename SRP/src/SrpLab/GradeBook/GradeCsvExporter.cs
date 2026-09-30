namespace SrpLab.GradeBook;

/// <summary>
/// Exports grade information as CSV.
/// </summary>
public sealed class GradeCsvExporter
{
    public string Export(
        GradeBook gradeBook,
        GradePolicy gradePolicy,
        HonorRollPolicy honorRollPolicy)
    {
        var rows = new List<string>
        {
            "studentId,average,letter,honor"
        };

        foreach (var studentId in gradeBook.StudentIds())
        {
            decimal average = gradeBook.Average(studentId);

            string letter =
                gradePolicy.Letter(average);

            bool honor =
                honorRollPolicy.MeetsHonorRoll(
                    average,
                    letter);

            rows.Add(
                $"{studentId},{average},{letter},{(honor ? 1 : 0)}");
        }

        return string.Join('\n', rows);
    }
}