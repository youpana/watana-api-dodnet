using System;
namespace WatanaApi.Sdk.Security
{
	public class Authentication
	{
		public Authentication(string url, string token) {
			this.url = url;
			this.token = token;
		}
        public Authentication()
        {
            this.url = Environment.GetEnvironmentVariable("WATANA_API_RUTA");
            this.token = Environment.GetEnvironmentVariable("WATANA_API_TOKEN");
        }
        public string url { get; set; }
        public string token { get; set; }
	}
}

