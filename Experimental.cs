using System;

// Clase que representa un contacto telefonico
public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }

    // Constructor
    public Contacto(string nombre, string telefono, string correo)
    {
        Nombre = nombre;
        Telefono = telefono;
        Correo = correo;
    }

    // Metodo para mostrar el contacto
    public void Mostrar()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Telefono: " + Telefono);
        Console.WriteLine("Correo: " + Correo);
        Console.WriteLine("-------------------------");
    }
}

class Program
{
    const int MAX_CONTACTOS = 3;
    static Contacto[] agenda = new Contacto[MAX_CONTACTOS];
    static int contador = 0;  // Contador de contactos agregados

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n-- MENU AGENDA TELEFONICA --");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Consultar contacto por nombre");
            Console.WriteLine("3. Ver todos los contactos (reporteria)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
                AgregarContacto();
            else if (opcion == 2)
                BuscarContacto();
            else if (opcion == 3)
                VerContactos();
            else if (opcion != 0)
                Console.WriteLine("Opcion invalida.");

        } while (opcion != 0);

        Console.WriteLine("Programa finalizado.");
    }

    static void AgregarContacto()
    {
        if (contador >= MAX_CONTACTOS)
        {
            Console.WriteLine("Agenda llena, no se pueden agregar mas contactos.");
            return;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();

        Console.Write("Correo: ");
        string correo = Console.ReadLine();

        agenda[contador] = new Contacto(nombre, telefono, correo);
        contador++;

        Console.WriteLine("Contacto agregado correctamente.");
    }

    static void BuscarContacto()
    {
        Console.Write("Ingrese el nombre a buscar: ");
        string buscar = Console.ReadLine().ToLower();
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (agenda[i].Nombre.ToLower().Contains(buscar))
            {
                agenda[i].Mostrar();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    static void VerContactos()
    {
        if (contador == 0)
        {
            Console.WriteLine("Agenda vacia.");
            return;
        }

        Console.WriteLine("\n-- CONTACTOS REGISTRADOS --");
        for (int i = 0; i < contador; i++)
        {
            agenda[i].Mostrar();
        }
    }
}
