﻿using System;

namespace urlHandler.Common.Model
{
    public class Url
    {
        public Url(string url)
        {
            var uri = new Uri(url);
            Protocol = uri.Scheme;
            int startIndex = Protocol.Length + Uri.SchemeDelimiter.Length;
            UrlWithoutProtocol = url.Substring(startIndex, url.Length - startIndex);
			ProcessName = DynamicProcessName.Instance.GetParentProcessName();
        }

        public string Protocol { get; set; }
        public string UrlWithoutProtocol { get; set; }
        public string ProcessName { get; set; }
        public string FullUrl { get { return Protocol + Uri.SchemeDelimiter + UrlWithoutProtocol; } }
    }
}
