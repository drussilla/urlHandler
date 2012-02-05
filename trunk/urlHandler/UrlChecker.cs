using System;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using urlHandler.Configuration;

namespace urlHandler
{
    public static class UrlChecker
    {
        public static bool CheckUrl(string plainUrl)
        {
            Url url = new Url(plainUrl);

            if (CheckRules(url))
            {
                return true;
            }

            return false;
        }

        private static bool CheckRules(Url url)
        {
            RulesSection rulesConfig = LoadRules();

            if (rulesConfig == null)
            {
                throw new ConfigurationErrorsException("Failed to load RulesSection from config.");
            }

            foreach (RuleElement rule in rulesConfig.Rules)
            {
                if (CheckRule(rule, url))
                {
                    RunUrl(url, rule);
                    return true;
                }

                if (RunDefaultApp(url))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool RunDefaultApp(Url url)
        {
            DefaultApplicationsSection defApps = LoadDefaultApp();

            foreach (DefaultApplicationElement defApp in defApps.Applications)
            {
                if (defApp.Protocol.Equals(url.Protocol, StringComparison.InvariantCultureIgnoreCase))
                {
                    RunUrl(url, defApp.Application, defApp.Arguments);
                    return true;
                }
            }
            return false;
        }

        private static bool CheckRule(RuleElement rule, Url url)
        {
            if (!string.IsNullOrEmpty(rule.Protocol) &&
                !rule.Protocol.Equals(url.Protocol, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(rule.ProcessName) && 
                !rule.ProcessName.Equals(url.ProcessName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(rule.Pattern) &&
                !Regex.IsMatch(url.UrlWithoutProtocol, rule.Pattern))
            {
                return false;
            }

            return true;
        }

        private static void RunUrl(Url url, RuleElement rule)
        {
            RunUrl(url, rule.Application, rule.Arguments);
        }

        private static void RunUrl(Url url, string application, string argument)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = application;

            if (!string.IsNullOrEmpty(argument))
            {
                string arg = argument.Replace("%1", url.FullUrl);
                startInfo.Arguments = arg;
            }

            Process.Start(startInfo);
        }

        private static RulesSection LoadRules()
        {
            return ConfigurationManager.GetSection("RulesSection") as RulesSection;
        }

        private static DefaultApplicationsSection LoadDefaultApp()
        {
            return ConfigurationManager.GetSection("DefaultApplicationsSection") as DefaultApplicationsSection;
        }
    }
}
