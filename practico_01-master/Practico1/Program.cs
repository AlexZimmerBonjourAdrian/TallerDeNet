using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mi Primera app C#");

            string nombre = "";
            string documento = "";
            string fnacimiento = "";
            string exit = "N";
          string Option= "N";
            List<Persona> lista = new List<Persona>();
            List<string> prueba = new List<string>();




            while (exit == "N" || exit== "n") 
            {
                
                Console.WriteLine("1) Listar Personas");
                Console.WriteLine("2) ingresar Persona");
                Console.WriteLine("3) Filtrar y ListarPersonas");
                Console.WriteLine("Y) Exit");
                Option = Console.ReadLine();

                switch (Option)
                {

                    case "1":
               // Console.Clear();

                        bool isEmnty = IsEmpty(lista);
                        //Console.WriteLine("La lista esta vacia");
                        if (!isEmnty)
                        {
                            //Console.WriteLine("La lista esta vacia");
                             
                             prueba = lista.Select(x => "Nombre: " + x.Nombre + ", Documento: " +
                       x.Documento + ", F. Nacimiento: " + x.FechaNacimiento.ToString("dd-MM-yyyy") +
                       ", Edad: " + x.GetEdad()).ToList();

                            prueba.ForEach(x =>
                        {
                            Console.WriteLine(x);
                        });
                            
                            
                        }
                      else
                        {
                            Console.WriteLine("La lista esta vacia ");
                           
                         }
                        Console.WriteLine("Exit (Y/N):");
                        exit = Console.ReadLine();
                        Console.Clear();
                       break;


                    case "2":
                        Console.Clear();

                        #region BaseCodigo
                        
                        Console.WriteLine("Nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Documento:");
                        documento = Console.ReadLine();
                        Console.WriteLine("Fecha Nacimiento (dd-mm-aaaa):");
                        fnacimiento = Console.ReadLine();
                        DateTime nacimiento;
                        if (DateTime.TryParse(fnacimiento, out nacimiento) == true)
                        {


                            nacimiento= DateTime.ParseExact(fnacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        Persona p = new Persona(nombre, documento, nacimiento);
                            lista.Add(p);
                            Console.WriteLine("Lista Agregada");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar La Fecha");
                        }
                       
                        
                        Console.WriteLine("Exit (Y/N):");
                         exit = Console.ReadLine();
                        //Option = Console.ReadLine();
                        #endregion


                        break;

                    case "3":
                        //Console.Clear();

                        Console.WriteLine("Nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Documento:");
                        documento = Console.ReadLine();
                        
                        lista = lista.Where(x => x.Nombre == nombre && x.Documento.StartsWith(documento)==true).ToList();
                        Console.WriteLine();
                        prueba.ForEach(x =>
                        {
                            Console.WriteLine(x);
                        });
                        //Option = Console.ReadLine();
                        break;

                    case "Y":
                        exit = "Y";
                        break;
                    default:
                        Console.WriteLine("No existe ese comando");
                       // Option = Console.ReadLine();
                        break;
                }

               
            } 

                // Ordenamos la lista.
               // lista = lista.OrderByDescending(x => x.GetEdad()).ToList();

            // Mapeamos a una lista de string.
          /*  List<string> prueba = lista.Select(x => "Nombre: " + x.Nombre + ", Documento: " +
                    x.Documento + ", F. Nacimiento: " + x.FechaNacimiento.ToString("dd-MM-yyyy") +
                    ", Edad: " + x.GetEdad()).ToList();
          */

            // Imprimimos

            prueba.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            // Prueba Where
            lista = lista.Where(x => x.Nombre == "pepe" && x.GetEdad() > 50).ToList();
            Console.WriteLine();
            prueba.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            Console.ReadLine();
            }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }
    }
}
