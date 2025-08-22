namespace OneHelper.Dtos
{
    public sealed record UserRegisterRequestDto(string Username, string Password, string Gender,
        DateOnly DOB, string Email, string FirstName, string LastName, decimal Height,
        decimal Weight);

    public sealed record UserResponse( string Username, string Gender, DateOnly DOB,
        string Email, string FirstName, string LastName, decimal Height, decimal Weight);

    public sealed record UserRequest(string Username, string Password, string Email = "");
}
