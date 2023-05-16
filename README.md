# WatanaApi .NET


Nuestra Biblioteca .NET oficial de WatanaApi, es compatible con la [v1.0](https://ayuda.llama.pe/integracion/) de Watana API, con el cual tendrás la posibilidad de crear carpetas, consultarlas, eliminarlas, firmar pdfs, validarlos, y aplicarles sello de tiempo.


## Requisitos 

* .NET 6 o superior.
* Registrate [aquí](https://watana.pe/registro).
* Una vez registrado, si vas a realizar pruebas obtén tus llaves desde [aquí](https://watana.pe/auths).

> Recuerda que para obtener tus llaves debes ingresar a tu Watana.pe > WATANA API > ***Autenticacion***.

![alt tag](https://i.imgur.com/6i1moyJ.png)



## Instalación
Puedes pasar la RUTA y TOKEN en el constructor de la clase Authentication o no pasar parametros, pero deberas configurar variables de entorno en tu aplicacion.

```cs
using WatanaApi.Sdk.Security;

string url = "<RUTA>";
string token = "<TOKEN>";

Authentication authenticacion = new Authentication(url,token);
```
### Iniciando con variables de entorno (WATANA_API_RUTA y WATANA_API_TOKEN)
```cs
using WatanaApi.Sdk.Security;

Authentication authenticacion = new Authentication();
```
    

## Enviar Carpeta

[Ver ejemplo completo](/Examples/EnviarCarpeta.cs)

Puedes enviar una carpeta con archivos para ser firmada a Watana App.

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
data.Add("carpeta_codigo", "DOC0001");
data.Add("titulo", "Carpeta o Archivo de pruebas");
.....

var response = new WatanaApi.Sdk.EnviarCarpeta(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Consultar Carpeta

[Ver ejemplo completo](/Examples/ConsultarCarpeta.cs)

Puedes consultar el estado de una carpeta enviada a Watana App, usando el atributo "carpeta_codigo" y especificando el codigo de la carpeta enviada.

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
data.Add("carpeta_codigo", "DOC0001");

var response = new WatanaApi.Sdk.ConsultarCarpeta(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```
## Descargar Carpeta

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
data.Add("carpeta_codigo", "DOC0001");

var response = new WatanaApi.Sdk.DescargarCarpeta(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Eliminar Carpeta

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
data.Add("carpeta_codigo", "DOC0001");

var response = new WatanaApi.Sdk.EliminarCarpeta(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Validar PDF

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
/// Puedes enviar un FileStream y la libreria Zipeara y convertira a base64 automaticamente.
/// Tambien puedes enviar directamente el base64 en string o en byte[] (En este caso se sobreentiende que ya lo has zipeado y la libreria no hara)
/// data.Add("zip_base64, "XXXXXX");
data.Add("zip_base64", File.Open("C:\\signed.pdf", FileMode.Open));

var response = new WatanaApi.Sdk.ValidarPdf(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Firmar PDF

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
/// Puedes enviar un FileStream y la libreria Zipeara y convertira a base64 automaticamente.
/// Tambien puedes enviar directamente el base64 en string o en byte[] (En este caso se sobreentiende que ya lo has zipeado y la libreria no hara)
/// data.Add("zip_base64, "XXXXXX");
data.Add("zip_base64", File.Open("C:\\file.pdf", FileMode.Open));

var response = new WatanaApi.Sdk.FirmarPdf(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Sellar PDF

```cs
using WatanaApi.Sdk.Models;
// Creamos el objecto para rellenar los datos
WatanaApiObject data = new WatanaApiObject();
/// Puedes enviar un FileStream y la libreria Zipeara y convertira a base64 automaticamente.
/// Tambien puedes enviar directamente el base64 en string o en byte[] (En este caso se sobreentiende que ya lo has zipeado y la libreria no hara)
/// data.Add("zip_base64, "XXXXXX");
data.Add("zip_base64", File.Open("C:\\signed.pdf", FileMode.Open));

var response = new WatanaApi.Sdk.SellarPdf(authenticacion).Send(data);

// Mostramos la respuesta json en string
Console.WriteLine(response)
```

## Pruebas

Antes de pasar tu cuenta a producción, te recomendamos realizar pruebas de integración. Así garantizarás un correcto despliegue.



## Documentación
¿Necesitas más información para integrar `watana-api-dodnet`? La documentación completa se encuentra en [https://ayuda.llama.pe/integracion](https://ayuda.llama.pe/integracion)


