namespace SecureTradingApi.Services
{
    public interface ISecureTradingConfiguration
    {
        string Username { get; set; }
        string Password { get; set; }
        string SiteReference { get; set; }
        string Alias { get; set; }
        string Endpoint { get; set; }
        string Version { get; set; }
    }
}
