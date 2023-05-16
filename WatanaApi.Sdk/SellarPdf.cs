using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WatanaApi.Sdk
{
    public class SellarPdf
    {
        Security.Authentication authentication;
        public SellarPdf(Security.Authentication authentication)
        {
            this.authentication = authentication;
        }

        public string Send(Model.WatanaApiObject data)
        {
            if (!data.ContainsKey("operacion"))
            {
                data.Add("operacion", "sellar_pdf");
            }
            data.ValidarObligatorio("zip_base64");
            return Util.Util.Request(authentication, data);
        }
    }
}

