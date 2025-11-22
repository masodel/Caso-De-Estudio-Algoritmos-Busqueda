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
                    case 2:
                        BusquedaBinaria();
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

        // Método para búsqueda binaria de autores
        static void BusquedaBinaria()
        {
            List<Libro> ordenados = new List<Libro>(Libros);
            ordenados.Sort((a, b) => a.Autor.CompareTo(b.Autor));

            Console.Write("Ingrese el autor a buscar: ");
            string autorBuscado = Console.ReadLine().ToLower();

            int inicio = 0;
            int fin = ordenados.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                string actual = ordenados[medio].Autor.ToLower();

                int comparacion = string.Compare(actual, autorBuscado, StringComparison.Ordinal);

                if (comparacion == 0)
                {
                    Console.WriteLine($"Autor encontrado: {ordenados[medio].Autor} - Libro: {ordenados[medio].Titulo}");
                    return;
                }
                else if (comparacion < 0)
                {
                    inicio = medio + 1;
                    Console.WriteLine("Autor no encontrado.");
                }



            }
        }
    }
}
   