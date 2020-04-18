namespace SecureVault.Web
{
    public class Settings
    {
        public ConnectionString ConnectionString { get; set; }
    }

    public class ConnectionString
    {
        public string SecureVaultDB { get; set; }
    }
}
