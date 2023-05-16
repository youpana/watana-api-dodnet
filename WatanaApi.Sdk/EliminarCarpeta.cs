﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WatanaApi.Sdk
{
    public class EliminarCarpeta
    {
        Security.Authentication authentication;
        public EliminarCarpeta(Security.Authentication authentication)
        {
            this.authentication = authentication;
        }

        public string Send(Model.WatanaApiObject data)
        {
            if (!data.ContainsKey("operacion"))
            {
                data.Add("operacion", "eliminar_carpeta");
            }
            data.ValidarObligatorio("carpeta_codigo");

            return Util.Util.Request(authentication, data);
        }
    }
}

