using System;

namespace LibrarySystem;

public class Loan
{
    private static int _nextLoanId = 1;

    public int LoanId { get; }

    public DateTime BorrowDate { get; }

    public DateTime DueDate
    {
        get
        {
            return BorrowDate.AddDays(Item.GetLoanPeriod());
        }
    }

    public DateTime? ReturnDate { get; private set; }

    public LoanStatus Status { get; private set; }

    public decimal LateFee
    {
        get
        {
            if (Status != LoanStatus.Returned)
            {
                return 0;
            }

            if (ReturnDate == null)
            {
                return 0;
            }

            if (ReturnDate.Value <= DueDate)
            {
                return 0;
            }

            TimeSpan difference = ReturnDate.Value - DueDate;

            int lateDays = difference.Days;

            decimal originalFee =
                lateDays * Item.GetDailyLateFee();

            decimal discount =
                originalFee * Member.DiscountPercentage / 100;

            return originalFee - discount;
        }
    }

    public Member Member { get; }

    public LibraryItem Item { get; }

    internal Loan(
        Member member,
        LibraryItem item,
        DateTime borrowDate)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        Member = member;
        Item = item;
        BorrowDate = borrowDate;

        LoanId = _nextLoanId++;
        Status = LoanStatus.Borrowed;
        ReturnDate = null;
    }

    public void Return(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
        {
            throw new InvalidOperationException(
                "Only a borrowed loan can be returned.");
        }

        if (returnDate < BorrowDate)
        {
            throw new ArgumentException(
                "Return date cannot be earlier than borrow date.");
        }

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;

        Item.SetOnLoan(false);
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
        {
            throw new InvalidOperationException(
                "Only a borrowed loan can be marked as lost.");
        }

        Status = LoanStatus.Lost;
    }
}