namespace SrpLab.Loan_Desk;

/// <summary>
/// Generates loan decision letters.
/// </summary>
public sealed class LoanDecisionLetter
{
    private readonly LoanRiskCalculator _riskCalculator =
        new();

    private readonly LoanEligibilityPolicy _eligibilityPolicy =
        new();

    private readonly LoanDocumentRequirements _documentRequirements =
        new();

    public string Generate(
        LoanDesk loan,
        string applicantName)
    {
        decimal riskScore =
            _riskCalculator.RiskScore(loan);

        bool eligible =
            _eligibilityPolicy.IsEligible(loan);

        if (eligible)
        {
            var documents =
                _documentRequirements.RequiredDocuments(loan);

            return
                $"Dear {applicantName},\n" +
                $"Your request for {loan.RequestedAmount:C} " +
                $"is pre-approved (risk {riskScore:0}).\n" +
                $"Please upload: " +
                $"{string.Join("; ", documents)}.\n";
        }

        return
            $"Dear {applicantName},\n" +
            $"We are unable to approve " +
            $"{loan.RequestedAmount:C} at this time.\n" +
            $"Reference risk={riskScore:0}. " +
            $"You may reapply after improving documentation.\n";
    }
}