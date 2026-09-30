namespace SrpLab.Loan_Desk;

/// <summary>
/// Determines the documents required for a loan application.
/// </summary>
public sealed class LoanDocumentRequirements
{
    private readonly LoanEligibilityPolicy _eligibilityPolicy =
        new();

    public IReadOnlyList<string> RequiredDocuments(
        LoanDesk loan)
    {
        var documents =
            new List<string>
            {
                "National ID",
                "Proof of income (3 months)"
            };

        if (loan.RequestedAmount > 40_000m)
        {
            documents.Add(
                "Bank statements (6 months)");
        }

        if (loan.HasCollateral)
        {
            documents.Add(
                "Collateral ownership deed");
        }

        if (loan.EmploymentMonths < 12)
        {
            documents.Add(
                "Employer letter");
        }

        if (!_eligibilityPolicy.IsEligible(loan))
        {
            documents.Add(
                "Manual underwriter referral form");
        }

        return documents;
    }
}