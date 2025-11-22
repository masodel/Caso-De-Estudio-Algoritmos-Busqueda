using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_De_Estudio
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public string Descripcion { get; set; }
    }

    public class Program
    {
        static List<Libro> Libros = new List<Libro>
        {
            new Libro {Titulo="C# Basico", Autor="Perez", Anio=2018, Descripcion="Introducción al lenguaje C#"},
            new Libro {Titulo="POO Avanzada", Autor="Gomez", Anio=2020, Descripcion="Principios de programación orientada a objetos"},
            new Libro {Titulo="Estructuras de Datos", Autor="Lopez", Anio=2015, Descripcion="Uso de listas, árboles y grafos"},
            new Libro {Titulo="Algoritmos Modernos", Autor="Martinez", Anio=2022, Descripcion="Técnicas algorítmicas actuales"}
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("===== MENU PRINCIPAL =====");
                Console.WriteLine("1. Búsqueda lineal (Solo en branch lineal)");
                Console.WriteLine("2. Búsqueda binaria (Solo en branch binaria)");
                Console.WriteLine("3. Libro más reciente y más antiguo");
                Console.WriteLine("4. Búsqueda por palabra clave en descripción");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        BusquedaLineal();
                        break;
                    case 3:
                        BuscarRecientes();
                        break;
                    case 4:
                        BuscarCoincidenciaDescripcion();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo…");
                        break;
                    default:
                        Console.WriteLine("Esta opción solo funciona en la rama correspondiente.");
                        break;
                }

            } while (opcion != 0);
        }

        static void BuscarRecientes()
        {
            // Falta implementar
        }

        static void BuscarCoincidenciaDescripcion()
        {
            // Falta implementar
        }

        // Método para búsqueda lineal
        static void BusquedaLineal()
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine().ToLower();

            foreach (var libro in Libros)
            {
                if (libro.Titulo.ToLower() == titulo)
                {
                    Console.WriteLine($"Libro encontrado: {libro.Titulo} ({libro.Autor}, {libro.Anio})");
                    return;
                }
            }

            Console.WriteLine("Libro no encontrado.");
        }
    }
}
