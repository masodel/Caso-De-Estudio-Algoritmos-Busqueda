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
                Console.WriteLine("1. Buscar por Título");
                Console.WriteLine("2. Buscar por Autor");
                Console.WriteLine("3. Libro más reciente y más antiguo");
                Console.WriteLine("4. Búsqueda por palabra clave en descripción");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("\nEntrada inválida.\n");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        BusquedaLineal();
                        break;
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
                        Console.WriteLine("\nSeleccione una opción válida\n");
                        break;
                }

            } while (opcion != 0);
        }

        static void BuscarRecientes()
        {
            Libro reciente = Libros[0];
            Libro antiguo = Libros[0];

            foreach (var libro in Libros)
            {
                if (libro.Anio > reciente.Anio)
                    reciente = libro;

                if (libro.Anio < antiguo.Anio)
                    antiguo = libro;
            }

            Console.WriteLine($"\nLibro más reciente: {reciente.Titulo} ({reciente.Anio})");
            Console.WriteLine($"Libro más antiguo: {antiguo.Titulo} ({antiguo.Anio})\n");
        }

        static void BuscarCoincidenciaDescripcion()
        {
            Console.Write("\nPalabra clave: ");
            string palabra = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(palabra))
            {
                Console.WriteLine("\nLa palabra clave no puede estar vacía.\n");
                return;
            }

            Console.WriteLine("\nCoincidencias encontradas:");
            bool encontrado = false;

            foreach (var libro in Libros)
            {
                if (libro.Descripcion.ToLower().Contains(palabra))
                {
                    Console.WriteLine($"• {libro.Titulo} — {libro.Descripcion}");
                    encontrado = true;
                }
            }

            if (!encontrado) { Console.WriteLine("\nNo hubo coincidencias.\n"); return; }

            Console.WriteLine();
        }

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
                    Console.WriteLine($"\nAutor encontrado: {ordenados[medio].Autor} - Libro: {ordenados[medio].Titulo}\n");
                    return;
                }
                else if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }

            Console.WriteLine("\nAutor no encontrado.\n");
        }

        static void BusquedaLineal()
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine().ToLower();

            foreach (var libro in Libros)
            {
                if (libro.Titulo.ToLower() == titulo)
                {
                    Console.WriteLine($"\nLibro encontrado: {libro.Titulo} ({libro.Autor}, {libro.Anio})\n");
                    return;
                }
            }

            Console.WriteLine("\nLibro no encontrado.\n");
        }
    }
}
   
