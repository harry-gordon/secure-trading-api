using SecureTradingApi.Services;

namespace SecureTradingApi.Example
{
    public class SecureTradingConfiguration : ISecureTradingConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SiteReference { get; set; }
        public string Alias { get; set; }
        public string Endpoint { get; set; }
        public string Version { get; set; }
    }
}
