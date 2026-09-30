namespace SrpLab.Loan_Desk;

/// <summary>
/// Exports loan application information for underwriter analytics.
/// </summary>
public sealed class LoanUnderwriterCsvExporter
{
    private readonly LoanRiskCalculator _riskCalculator =
        new();

    private readonly LoanEligibilityPolicy _eligibilityPolicy =
        new();

    public string Export(
        LoanDesk loan,
        string applicationId)
    {
        decimal riskScore =
            _riskCalculator.RiskScore(loan);

        bool eligible =
            _eligibilityPolicy.IsEligible(loan);

        return
            $"{applicationId}," +
            $"{loan.CreditScore}," +
            $"{loan.EmploymentMonths}," +
            $"{(loan.HasCollateral ? 1 : 0)}," +
            $"{riskScore:0.00}," +
            $"{(eligible ? "Y" : "N")}";
    }
}