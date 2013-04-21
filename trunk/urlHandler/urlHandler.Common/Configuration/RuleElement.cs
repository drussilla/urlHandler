using System.Configuration;

namespace urlHandler.Common.Configuration
{
    public class RuleElement : ConfigurationElement
    {
        private const string regExBegin = "^";
        private const string regExEnd = "(/.*)?$";
        private const string protocolDelimiter = "://";
        private const string defaultArguments = "%1";

        public RuleElement()
        {
            Protocol = string.Empty;
            ProcessName = string.Empty;
            Pattern = string.Empty;
            Application = string.Empty;
            Arguments = string.Empty;
        }

        public RuleElement(string url)
        {
            int index = url.IndexOf(protocolDelimiter, System.StringComparison.Ordinal);
            string site;
            string protocol;
            if (index != -1)
            {
                protocol = url.Substring(0, index);
                int siteLength = url.Length - (index + protocolDelimiter.Length);
                site = url.Substring(index + protocolDelimiter.Length, siteLength);
            }
            else
            {
                protocol = string.Empty;
                site = url;
            }

            Protocol = protocol;
            Pattern = regExBegin + site + regExEnd;
            Arguments = defaultArguments;
            Name = url + "_rule";
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

        public string ToUrlString()
        {
            string res = string.Empty;
            if (!string.IsNullOrEmpty(Protocol))
            {
                res += Protocol + protocolDelimiter;
            }

            if (!string.IsNullOrEmpty(Pattern) && Pattern.StartsWith(regExBegin) && Pattern.EndsWith(regExEnd))
            {
                res += Pattern.Substring(regExBegin.Length, Pattern.Length - regExEnd.Length - 1);
            }
            else if (!string.IsNullOrEmpty(Pattern))
            {
                res += Pattern;
            }

            return res;
        }
    }
}
