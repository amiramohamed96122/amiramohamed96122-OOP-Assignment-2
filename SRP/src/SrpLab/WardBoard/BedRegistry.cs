namespace SrpLab.WardBoard;

public sealed class BedRegistry
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    public void Assign(int bed, string patientId, int acuity)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _vitalsScore[bed] = acuity;
    }

    public bool TryGet(int bed, out string patient, out int acuity)
    {
        if (_bedPatient.TryGetValue(bed, out patient!))
        {
            acuity = _vitalsScore[bed];
            return true;
        }

        acuity = 0;
        return false;
    }

    public IEnumerable<int> GetBeds()
    {
        return _bedPatient.Keys;
    }

    public string GetPatient(int bed)
    {
        return _bedPatient[bed];
    }

    public int GetAcuity(int bed)
    {
        return _vitalsScore[bed];
    }
}
