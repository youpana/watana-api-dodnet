using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using WatanaApi.Sdk.Model;
using WatanaApi.Sdk.Security;
using WatanaApi.Sdk.Util;

string url = "<RUTA>";
string token = "<TOKEN>";

// NOS AUTENTICAMOS
var authenticacion = new Authentication(url, token);
// CARGAMOS LOS DATOS
var data = new WatanaApiObject();
data.Add("carpeta_codigo", "DOC001");
data.Add("titulo", "Documento o carpeta de ejemplo");
data.Add("descripcion", "Esta es la descripción de este documento");
data.Add("observaciones", "");
data.Add("vigencia_horas", 24);
data.Add("reemplazar", true);
data.Add("firmante", new WatanaApiObject(
    new List<WatanaApiValue> {
        new WatanaApiValue("email", "firmante@example.com"),
        new WatanaApiValue("nombre_completo", "FULANO"),
}));
data.Add("archivos", new List<WatanaApiObject> {
    new WatanaApiObject(new List<WatanaApiValue>{
        new WatanaApiValue("nombre", "archivo.pdf"),
        new WatanaApiValue("zip_base64", File.Open("file.pdf", FileMode.Open)),
        new WatanaApiValue("firma_visual", new WatanaApiObject(new List<WatanaApiValue> {
                new WatanaApiValue("imagen_zip_base64", File.Open("imagen.png", FileMode.Open)),
                new WatanaApiValue("ubicacion_x", 0),
                new WatanaApiValue("ubicacion_y", 0),
                new WatanaApiValue("largo", 300),
                new WatanaApiValue("alto", 40),
                new WatanaApiValue("pagina", 1),
                new WatanaApiValue("texto", @"Firmado digitalmente por: <FIRMANTE>
     <ORGANIZACION>
     <TITULO>
     <CORREO>
     <DIRECCION>
     <FECHA>
      Firmado con Watana"),
        }))

    }),
});

// ENVIAMOS AL API
var response = new WatanaApi.Sdk.EnviarCarpeta(authenticacion).Send(data);

// MOSTRAMOS RESPUESTA
Debug.WriteLine(response);
