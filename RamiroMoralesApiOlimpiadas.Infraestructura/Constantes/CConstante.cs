using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Infraestructura.Constantes
{
    public class CConstante
    {
        public static class Mensajes{
            public const string MensajeIntentos = "Alcanzado el numero maximo de intentos";
            public const string MensajeExitoso = "Proceso Exitoso";
        }
        public static class Codigo
        {
            public const string CodigoFallo = "400";
            public const string CodigoExitoso = "200";
        }

        public static class Credenciales
        {
            public const string Correo  = "ramimorales1986@gmail.com";
            public const string Clave = "12345";
        }

        }
}
