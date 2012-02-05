using System.Configuration;

namespace urlHandler.Configuration
{
    public class DefaultApplicationElement : ConfigurationElement
    {
        public DefaultApplicationElement()
        {
            this.Protocol = string.Empty;
            this.Application = string.Empty;
            this.Arguments = string.Empty;
        }

        [ConfigurationProperty("Protocol", IsRequired = true, IsKey = true)]
        public string Protocol
        {
            get
            {
                return this["Protocol"] as string;
            }
            set
            {
                this["Protocol"] = value;
            }
        }

        [ConfigurationProperty("Application", IsRequired = true)]
        public string Application
        {
            get
            {
                return this["Application"] as string;
            }

            set
            {
                this["Application"] = value;
            }
        }

        [ConfigurationProperty("Arguments", IsRequired = true)]
        public string Arguments
        {
            get
            {
                return this["Arguments"] as string;
            }

            set
            {
                this["Arguments"] = value;
            }
        }
    }
}
