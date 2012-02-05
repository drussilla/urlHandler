using System.Configuration;

namespace urlHandler.Configuration
{
    public class RuleElement : ConfigurationElement
    {
        public RuleElement()
        {
            this.Protocol = string.Empty;
            this.ProcessName = string.Empty;
            this.Pattern = string.Empty;
            this.Application = string.Empty;
            this.Arguments = string.Empty;
        }

        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["Name"] as string;
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("Protocol")]
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

        [ConfigurationProperty("ProcessName")]
        public string ProcessName
        {
            get
            {
                return this["ProcessName"] as string;
            }

            set
            {
                this["ProcessName"] = value;
            }
        }

        [ConfigurationProperty("Pattern")]
        public string Pattern
        {
            get
            {
                return this["Pattern"] as string;
            }
            set
            {
                this["Pattern"] = value;
            }
        }

        [ConfigurationProperty("Application")]
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

        [ConfigurationProperty("Arguments")]
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
