﻿using Seguro.Negocio;
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
            Cliente cli = new Cliente()
            {
                Rut = "17256155-1",
                Pass = "1234"
            };

            cli.Leer();

            SiniestroColeccion col = new SiniestroColeccion();

            Console.WriteLine(cli.Ciudad.Nombre);
            Console.ReadLine();
        }
    }
}
