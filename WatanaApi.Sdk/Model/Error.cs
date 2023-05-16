using System;
namespace WatanaApi.Sdk.Model
{
	public class WatanaError : Exception
	{
		public WatanaError()
		{
		}
        public WatanaError(string msj) : base(msj)
        {

        }
    }
    public class ErrorCampoOblogatorio : WatanaError
    {
        public ErrorCampoOblogatorio() { }
        public ErrorCampoOblogatorio(string name) : base(String.Format("El atributo [{0}] es obligatorio", name))
        {

        }
    }

    public class ErrorAuthenticacion : WatanaError
    {
        public ErrorAuthenticacion() : base("La RUTA o TOKEN no son correctos, por favor verifique")
        {

        }
    }

   

}

