namespace NTierArchitecture.Entities.DTOs;

public sealed record UpdateStudentDto(
    Guid Id,
    string FirstName,
    string LastName,
    byte ClassNumber,
    int Number,
    string IdCardNumber);
