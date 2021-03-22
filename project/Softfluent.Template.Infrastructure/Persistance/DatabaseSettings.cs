namespace Softfluent.Template.Infrastructure.Persistance
{
    /// <summary>
    /// Define database settings.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Get or set server name.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Get or set user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get or set password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Get or set database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Get or set a value that indicates wether the user should use a trusted connection.
        /// </summary>
        public bool TrustedConnection { get; set; }
    }
}