using System;

namespace LibrarySystem;

public class Person
{
    private static List<string> _personIds = new List<string>();
    public string PersonId { get; }
    public string FullName { get; }
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        if (string.IsNullOrWhiteSpace(personId))
        {
            throw new ArgumentException("Person ID cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Phone cannot be empty.");
        }

        foreach (string id in _personIds)
        {
            if (id == personId)
            {
                throw new ArgumentException("Person ID must be unique.");
            }
        }

        PersonId = personId;
        FullName = fullName;
        Phone = phone;
        _personIds.Add(personId);
    }
}