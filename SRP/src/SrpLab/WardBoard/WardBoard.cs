namespace SrpLab.WardBoard;

/// <summary>
/// Coordinates ward bed assignment, acuity scoring, pager alerts,
/// handoff notes, and census export through focused components.
/// </summary>
public sealed class WardBoard
{
    private readonly BedRegistry _bedRegistry = new();
    private readonly AcuityScorer _acuityScorer = new();
    private readonly PagerAlertLog _pagerAlertLog = new();
    private readonly HandoffNoteFormatter _handoffNoteFormatter = new();
    private readonly CensusCsvExporter _censusCsvExporter = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        var acuity = _acuityScorer.Score(heartRate, spo2);

        _bedRegistry.Assign(bed, patientId, acuity);

        _pagerAlertLog.Add(bed, acuity);
    }

    public int ScoreAcuity(int heartRate, int spo2)
    {
        return _acuityScorer.Score(heartRate, spo2);
    }

    public string BuildHandoffNote(int bed)
    {
        if (!_bedRegistry.TryGet(bed, out var patient, out var acuity))
            return _handoffNoteFormatter.EmptyBed(bed);

        return _handoffNoteFormatter.Format(bed, patient, acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerAlertLog.Drain();
    }

    public string ExportCensusCsv()
    {
        return _censusCsvExporter.Export(_bedRegistry);
    }
}
