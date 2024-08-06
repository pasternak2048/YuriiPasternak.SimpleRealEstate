namespace YuriiPasternak.SimpleRealEstate.WebAPI.Contracts
{
    public record RegisterRequest(string? UserName, string? Password, string? FirstName, string? LastName);
}
