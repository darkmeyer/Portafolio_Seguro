using Seguro.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            ServicioSeguro.ServicioSeguroClient seguro = new ServicioSeguro.ServicioSeguroClient();
            Cliente cli = new Cliente()
            {
                Rut = "17256155-1",
                Pass = "1234"
            };

            cli.Leer();

            string xmlColeccion = seguro.leerSiniestros(cli.Id_cliente);
            SiniestroColeccion col = new SiniestroColeccion(xmlColeccion);

            Console.WriteLine(cli.Ciudad.Nombre);
            Console.ReadLine();
        }
    }
}
