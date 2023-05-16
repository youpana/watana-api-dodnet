
using System.Diagnostics;
using WatanaApi.Sdk.Security;

string url = "<RUTA>";
string token = "<TOKEN>";

// NOS AUTENTICAMOS
var authenticacion = new Authentication(url, token);
// CARGAMOS LOS DATOS
var data = new WatanaApi.Sdk.Model.WatanaApiObject();
data.Add("carpeta_codigo", "DOC0001");

// ENVIAMOS AL API
var response = new WatanaApi.Sdk.ConsultarCarpeta(authenticacion).Send(data);

// MOSTRAMOS RESPUESTA
Debug.WriteLine(response);
