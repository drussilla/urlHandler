using System;

namespace urlHandler
{
    public class Url
    {
        public Url(string url)
        {
            Uri uri = new Uri(url);
            Protocol = uri.Scheme;
            UrlWithoutProtocol = url.TrimStart((Protocol + Uri.SchemeDelimiter).ToCharArray());
            ProcessName = Win32ApiWrapper.GetParentProcessName();
        }

        public string Protocol { get; set; }
        public string UrlWithoutProtocol { get; set; }
        public string ProcessName { get; set; }
        public string FullUrl { get { return Protocol + Uri.SchemeDelimiter + UrlWithoutProtocol; } }
    }
}
