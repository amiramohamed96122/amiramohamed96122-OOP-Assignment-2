using System;
using System.Collections.Generic;

namespace LibrarySystem;

public class LibraryItem
{
    private static readonly List<string> _catalogNumbers =
        new List<string>();

    private readonly int _loanPeriodDays;
    private readonly decimal _lateFeeMultiplier;

    public string CatalogNumber { get; }

    public string Title { get; }

    public decimal BaseLateFee { get; private set; }

    public bool IsWithdrawn { get; private set; }

    public bool IsOnLoan { get; private set; }

    protected LibraryItem(
        string catalogNumber,
        string title,
        decimal baseLateFee,
        int loanPeriodDays,
        decimal lateFeeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber))
        {
            throw new ArgumentException(
                "Catalog number cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "Title cannot be empty.");
        }

        if (baseLateFee <= 0)
        {
            throw new ArgumentException(
                "Base late fee must be greater than zero.");
        }

        if (loanPeriodDays <= 0)
        {
            throw new ArgumentException(
                "Loan period must be greater than zero.");
        }

        foreach (string number in _catalogNumbers)
        {
            if (number == catalogNumber)
            {
                throw new ArgumentException(
                    "Catalog number must be unique.");
            }
        }

        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        _loanPeriodDays = loanPeriodDays;
        _lateFeeMultiplier = lateFeeMultiplier;

        IsWithdrawn = false;
        IsOnLoan = false;

        _catalogNumbers.Add(catalogNumber);
    }

    public void ChangeLateFee(decimal newFee)
    {
        if (newFee <= 0)
        {
            throw new ArgumentException(
                "Late fee must be greater than zero.");
        }

        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public int GetLoanPeriod()
    {
        return _loanPeriodDays;
    }

    public decimal GetDailyLateFee()
    {
        return BaseLateFee * _lateFeeMultiplier;
    }

    internal void SetOnLoan(bool value)
    {
        IsOnLoan = value;
    }
}