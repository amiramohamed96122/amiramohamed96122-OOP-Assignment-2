using System;
using System.Collections.Generic;

namespace LibrarySystem;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Library System ===");

        StudentMember student =
            new StudentMember(
                "M001",
                "Amira Mohamed",
                "01000000000");

        PremiumMember premium =
            new PremiumMember(
                "M002",
                "Sara Ahmed",
                "01111111111",
                20);

        Book book =
            new Book(
                "B001",
                "C# Programming",
                10);

        DVD dvd =
            new DVD(
                "D001",
                "C# Course",
                10);

        Magazine magazine =
            new Magazine(
                "MG001",
                "Technology Magazine",
                10);

        Console.WriteLine(student.FullName);
        Console.WriteLine(premium.FullName);

        Console.WriteLine(
            "Book loan period: " +
            book.GetLoanPeriod());

        Console.WriteLine(
            "DVD loan period: " +
            dvd.GetLoanPeriod());

        Console.WriteLine(
            "Magazine loan period: " +
            magazine.GetLoanPeriod());

        Loan loan =
            premium.Borrow(
                dvd,
                new DateTime(2026, 9, 1));

        Console.WriteLine(
            "Loan ID: " + loan.LoanId);

        Console.WriteLine(
            "Due date: " + loan.DueDate);

        premium.ReturnLoan(
            loan,
            new DateTime(2026, 9, 13));

        Console.WriteLine(
            "Status: " + loan.Status);

        Console.WriteLine(
            "Late fee: " + loan.LateFee);

        Console.WriteLine(
            "Reading points: " +
            premium.ReadingPoints);

        Console.WriteLine(
            "Total loans: " +
            premium.Loans.Count);
    }
}