using System;
using System.Collections.Generic;

namespace LibrarySystem;

public class Member : Person
{
    private readonly List<Loan> _loans = new List<Loan>();

    private readonly int _maxLoans;
    private readonly decimal _discountPercentage;

    public IReadOnlyList<Loan> Loans
    {
        get
        {
            return _loans.AsReadOnly();
        }
    }

    protected Member(
        string personId,
        string fullName,
        string phone,
        int maxLoans,
        decimal discountPercentage)
        : base(personId, fullName, phone)
    {
        if (maxLoans <= 0)
        {
            throw new ArgumentException("Maximum loans must be greater than zero.");
        }

        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Discount percentage must be between 0 and 100.");
        }

        _maxLoans = maxLoans;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountPercentage
    {
        get
        {
            return _discountPercentage;
        }
    }

    public Loan Borrow(LibraryItem item, DateTime borrowDate)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        int activeLoans = 0;

        foreach (Loan x in _loans)
        {
            if (x.Status == LoanStatus.Borrowed)
            {
                activeLoans++;
            }
        }

        if (activeLoans >= _maxLoans)
        {
            throw new InvalidOperationException(
                "Member cannot have more active loans than the allowed limit.");
        }

        if (item.IsWithdrawn)
        {
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");
        }

        if (item.IsOnLoan)
        {
            throw new InvalidOperationException(
                "This item is already on loan.");
        }

        Loan loan = new Loan(this, item, borrowDate);

        _loans.Add(loan);

        item.SetOnLoan(true);

        return loan;
    }

    public void ReturnLoan(Loan loan, DateTime returnDate)
    {
        if (loan == null)
        {
            throw new ArgumentNullException(nameof(loan));
        }

        if (loan.Member != this)
        {
            throw new InvalidOperationException(
                "This loan does not belong to this member.");
        }

        loan.Return(returnDate);
    }
}