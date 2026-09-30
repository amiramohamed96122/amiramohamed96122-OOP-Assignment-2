namespace SrpLab.WardBoard;

public sealed class CensusCsvExporter
{
    public string Export(BedRegistry registry)
    {
        var lines = new List<string>
        {
            "bed,patient,acuity"
        };

        foreach (var bed in registry.GetBeds().OrderBy(x => x))
        {
            lines.Add(
                $"{bed},{registry.GetPatient(bed)},{registry.GetAcuity(bed)}"
            );
        }

        return string.Join('\n', lines);
    }
}
