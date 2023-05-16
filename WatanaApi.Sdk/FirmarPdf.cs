using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WatanaApi.Sdk
{
    public class FirmarPdf
    {
        Security.Authentication authentication;
        public FirmarPdf(Security.Authentication authentication)
        {
            this.authentication = authentication;
        }

        public string Send(Model.WatanaApiObject data)
        {
            if (!data.ContainsKey("operacion"))
            {
                data.Add("operacion", "firmar_pdf");
            }
            data.ValidarObligatorio("zip_base64");
            return Util.Util.Request(authentication, data);
        }
    }
}

