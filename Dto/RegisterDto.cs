namespace OneHelper.Dto
{
    public sealed record RegisterDto(string Username, string Password, string Gender, DateOnly DateOfBirth,
    string FirstName, string LastName, decimal Height, decimal Weight);
}
