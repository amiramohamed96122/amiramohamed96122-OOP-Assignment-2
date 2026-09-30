namespace SrpLab.Loan_Desk;

/// <summary>
/// Determines whether a loan application is eligible.
/// </summary>
public sealed class LoanEligibilityPolicy
{
    private readonly LoanRiskCalculator _riskCalculator =
        new();

    public bool IsEligible(LoanDesk loan)
    {
        decimal riskScore =
            _riskCalculator.RiskScore(loan);

        return riskScore >= 55m &&
               loan.CreditScore >= 580;
    }
}