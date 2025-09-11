namespace OneHelper.Dto
{
    public sealed record RegisterDto(string UserName, string Password, string Gender, DateOnly DateOfBirth, string Email,
        string? PhoneNumber, string FirstName, string LastName, decimal Height, decimal Weight);
}
