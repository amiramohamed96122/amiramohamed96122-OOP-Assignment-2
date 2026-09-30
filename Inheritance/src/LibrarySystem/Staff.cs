using System;

namespace LibrarySystem;

public class Staff : Person
{
    private readonly decimal _responsibilityAllowance;

    public DateTime HireDate { get; }

    public decimal MonthlySalary { get; private set; }

    protected Staff(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        decimal responsibilityAllowance)
        : base(personId, fullName, phone)
    {
        if (monthlySalary < 0)
        {
            throw new ArgumentException(
                "Monthly salary cannot be negative.");
        }

        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        _responsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
        {
            throw new ArgumentException(
                "Raise percentage must be greater than zero.");
        }

        MonthlySalary =
            MonthlySalary + (MonthlySalary * percentage / 100);
    }

    public decimal GetMonthlyPay()
    {
        return MonthlySalary + _responsibilityAllowance;
    }
}