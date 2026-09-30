using System;

namespace LibrarySystem;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base(
            personId,
            fullName,
            phone,
            hireDate,
            monthlySalary,
            400)
    {
    }

    public void ChangeLateFee(
        LibraryItem item,
        decimal newFee)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        item.ChangeLateFee(newFee);
    }

    public void Withdraw(LibraryItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        item.Withdraw();
    }

    public void Restore(LibraryItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        item.Restore();
    }
}