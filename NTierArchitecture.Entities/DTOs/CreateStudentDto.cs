namespace NTierArchitecture.Entities.DTOs;
public sealed record CreateStudentDto(
    string FirstName,
    string LastName,
    byte ClassNumber,
    int Number,
    string IdCardNumber);
