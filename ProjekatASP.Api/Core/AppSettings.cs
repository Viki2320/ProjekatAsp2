namespace ProjekatASP.Api.Core
{
    public class AppSettings
    {
        public string ConnString { get; set; }
        public EmailOptions EmailOptions { get; set; }
        public JwtSettings JwtSettings { get; set; }
        
    }

    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
       
    }
}
