using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious
{
    public class UrlQuery
    {
        protected string baseUrl;
        private IDictionary<string, string> @params;
        private const string paramsSeparator = "&";

        public UrlQuery (string baseUrl)
	    {
            this.baseUrl = baseUrl;
            @params = new Dictionary<string, string>();
	    }

        public void Add(string parameterName, string parameterValue)
        {
            @params.Add(parameterName, parameterValue);
        }

        public string GetUrl()
        {
            string url = baseUrl;
            if(@params.Count > 0)
            {
                url += "?";
                foreach(var param in @params)
                {
                    if (!string.IsNullOrEmpty(param.Value.Trim()))
                    {
                        url += param.Key + "=" + param.Value + paramsSeparator;
                    }
                }
                url = url.TrimEnd(paramsSeparator.ToCharArray());
                
            }
            return url;
        }

        public override string ToString()
        {
            return GetUrl();
        }
    }
}
