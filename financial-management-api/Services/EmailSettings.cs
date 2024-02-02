namespace financial_management_api.Services
{
    public class EmailSettings
    {
        public string? SmtpServer { get; internal set; }
        public int SmtpPort { get; internal set; }
        public bool EnableSsl { get; internal set; }
        public string? EmailFrom { get; internal set; }
        public string? Password { get; internal set; }
    }
}
