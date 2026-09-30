namespace SrpLab.CourseEnrollmentDesk;

public sealed class TuitionInvoiceFormatter
{
    private const decimal VatRate = 0.14m;

    public string Format(
        string courseCode,
        decimal tuition,
        bool isSeated)
    {
        if (!isSeated)
            return $"{courseCode},WAITLIST,0.00";

        var vat = Math.Round(
            tuition * VatRate,
            2);

        return $"{courseCode}," +
               $"TUITION,{tuition:0.00}," +
               $"VAT,{vat:0.00}," +
               $"TOTAL,{tuition + vat:0.00}";
    }
}