namespace YuriiPasternak.SimpleRealEstate.WebAPI.Contracts
{
    public record AuthenticationResponse(
        Guid Id,
        string UserName,
        string FirstName,
        string LastName,
        string Email
        ,string Role,
        string Token);
}
