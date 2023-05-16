using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WatanaApi.Sdk
{
    public class EnviarCarpeta
    {
        Security.Authentication authentication;
        public EnviarCarpeta(Security.Authentication authentication)
        {
            this.authentication = authentication;
        }

        public string Send(Model.WatanaApiObject data)
        {
            if (!data.ContainsKey("operacion"))
            {
                data.Add("operacion", "enviar_carpeta");
            }
            data.ValidarObligatorio("carpeta_codigo");
            data.ValidarObligatorio("titulo");
            data.ValidarObligatorio("firmante");
            data.ValidarObligatorio("archivos");

            return Util.Util.Request(authentication, data);
        }
    }
}

