using System;
using System.Collections.Generic;

namespace CitasMedicas
{
    
    public class Estudiante
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Universidad { get; set; }

        public Estudiante(int codigo, string nombre, string universidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Universidad = universidad;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Universidad: {Universidad}";
        }
    }
    public class Cita
    {
        public int Numero { get; set; }
        public Estudiante Estudiante { get; set; }
        public string Enfermedad { get; set; }
        public double Precio { get; set; }

        public Cita(int numero, Estudiante estudiante, string enfermedad, double precio)
        {
            Numero = numero;
            Estudiante = estudiante;
            Enfermedad = enfermedad;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Número de cita: {Numero}, Enfermedad: {Enfermedad}, Estudiante: {Estudiante.Nombre}, Universidad: {Estudiante.Universidad}, Precio: {Precio:C}";
        }
    }

    class Program
    {
        
        static List<Cita> citas = new List<Cita>();
        static int numeroCita = 1; 

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("Menu de opciones:");
                Console.WriteLine("1. Crear Cita");
                Console.WriteLine("2. Listar Citas");
                Console.WriteLine("3.  Universidad ");
                Console.WriteLine("4. Fin");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearCita();
                        break;
                    case 2:
                        ListarCitas();
                        break;
                    case 3:
                        Universidad();
                        break;
                    case 4:
                        Console.WriteLine("Fin del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            } while (opcion != 4);
        }

        private static void Universidad()
        {
            throw new NotImplementedException();
        }

        static void CrearCita()
        {
            Console.WriteLine(" Crear Cita ");

            Console.Write("Ingrese el código del estudiante: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la universidad del estudiante: ");
            string universidad = Console.ReadLine();

            Estudiante estudiante = new Estudiante(codigo, nombre, universidad);

            Console.Write("Ingrese la enfermedad: ");
            string enfermedad = Console.ReadLine();

            Console.Write(" precio: ");
            double precio = double.Parse(Console.ReadLine());

            Cita nuevaCita = new Cita(numeroCita++, estudiante, enfermedad, precio);
            citas.Add(nuevaCita);

            Console.WriteLine("Cita creada exitosamente.");
        }

        
        static void ListarCitas()
        {
            Console.WriteLine(" Listado de Citas ");
            double sumaTotal = 0;

            foreach (Cita cita in citas)
            {
                Console.WriteLine(cita);
                sumaTotal += cita.Precio;
            }

            Console.WriteLine($"Suma total de precios: {sumaTotal:C}");
        }

        static void universisad()
        {
            Console.WriteLine(" Universidad  ");
            Console.Write("Ingrese el texto a buscar en el nombre de la universidad: ");
            string textoBuscar = Console.ReadLine();

            Console.Write("Ingrese el nuevo texto para reemplazar: ");
            string textoReemplazar = Console.ReadLine();

            foreach (Cita cita in citas)
            {
                if (cita.Estudiante.Universidad.Contains(textoBuscar))
                {
                    cita.Estudiante.Universidad = cita.Estudiante.Universidad.Replace(textoBuscar, textoReemplazar);
                }
            }

            Console.WriteLine("Modificación masiva completada.");
        }
    }
}
