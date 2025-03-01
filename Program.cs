using System;
using System.IO;

class Program
{
    static string directorioBase = @"C:\LaboratorioAvengers";
    static string archivoInventos = Path.Combine(directorioBase, "inventos.txt");
    static string carpetaBackup = Path.Combine(directorioBase, "Backup");
    static string carpetaArchivosClasificados = Path.Combine(directorioBase, "ArchivosClasificados");
    static string carpetaProyectosSecretos = Path.Combine(directorioBase, "ProyectosSecretos");

    static void Main(string[] args)
    {
        CrearDirectorio(directorioBase);
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        Console.Clear();

        Console.WriteLine("------------LaboratorioAvengers-------------");
        Console.WriteLine("1. Crear archivo de inventos");
        Console.WriteLine("2. Agregar invento");
        Console.WriteLine("3. Leer archivo línea por línea");
        Console.WriteLine("4. Leer todo el archivo");
        Console.WriteLine("5. Copiar archivo");
        Console.WriteLine("6. Mover archivo");
        Console.WriteLine("7. Crear carpeta");
        Console.WriteLine("8. Verificar existencia de archivo");
        Console.WriteLine("9. Eliminar archivo");
        Console.WriteLine("10. Listar archivos");
        Console.WriteLine("0. Salir");


        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                CrearArchivo();
                break;
            case "2":
                Console.Write("Ingrese el nombre del invento a agregar: ");
                string invento = Console.ReadLine();
                AgregarInvento(invento);
                break;
            case "3":
                LeerLineaPorLinea();
                break;
            case "4":
                LeerTodoElTexto();
                break;
            case "5":
                CopiarArchivo();
                break;
            case "6":
                MoverArchivo();
                break;
            case "7":
                CrearCarpeta();
                break;
            case "8":
                VerificarExistenciaArchivo();
                break;
            case "9":
                EliminarArchivo();
                break;
            case "10":
                ListarArchivos();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        MostrarMenu();
    }

    static void CrearArchivo()
    {
        try
        {
            if (!File.Exists(archivoInventos))
            {
                File.Create(archivoInventos).Close();
                Console.WriteLine("Archivo 'inventos.txt' creado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo 'inventos.txt' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el archivo: {ex.Message}");
        }
    }

    static void AgregarInvento(string invento)
    {
        try
        {
            File.AppendAllText(archivoInventos, invento + Environment.NewLine);
            Console.WriteLine($"Invento '{invento}' agregado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar el invento: {ex.Message}");
        }
    }

    static void LeerLineaPorLinea()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                var lineas = File.ReadLines(archivoInventos);
                foreach (var linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        }
    }

    static void LeerTodoElTexto()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                string contenido = File.ReadAllText(archivoInventos);
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        }
    }

    static void CopiarArchivo()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                CrearDirectorio(carpetaBackup);
                string archivoDestino = Path.Combine(carpetaBackup, "inventos_backup.txt");
                File.Copy(archivoInventos, archivoDestino, true);
                Console.WriteLine("Archivo copiado exitosamente a 'Backup'.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
        }
    }

    static void MoverArchivo()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                CrearDirectorio(carpetaArchivosClasificados);
                string archivoDestino = Path.Combine(carpetaArchivosClasificados, "inventos.txt");
                File.Move(archivoInventos, archivoDestino);
                archivoInventos = archivoDestino;
                Console.WriteLine("Archivo movido exitosamente a 'ArchivosClasificados'.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mover el archivo: {ex.Message}");
        }
    }

    static void CrearCarpeta()
    {
        Console.Write("Ingrese el nombre de la carpeta: ");
        string nombreCarpeta = Console.ReadLine();
        string rutaCarpeta = Path.Combine(directorioBase, nombreCarpeta);

        try
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
                Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
            }
            else
            {
                Console.WriteLine($"La carpeta '{nombreCarpeta}' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la carpeta: {ex.Message}");
        }
    }

    static void VerificarExistenciaArchivo()
    {
        if (File.Exists(archivoInventos))
        {
            Console.WriteLine("El archivo 'inventos.txt' existe.");
        }
        else
        {
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
    }

    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                File.Delete(archivoInventos);
                Console.WriteLine("Archivo 'inventos.txt' eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
        }
    }

    static void ListarArchivos()
    {
        try
        {
            if (Directory.Exists(directorioBase))
            {
                var archivos = Directory.GetFiles(directorioBase);
                Console.WriteLine("Archivos en 'LaboratorioAvengers':");
                foreach (var archivo in archivos)
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
            else
            {
                Console.WriteLine("Error: El directorio 'LaboratorioAvengers' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar los archivos: {ex.Message}");
        }
    }

    static void CrearDirectorio(string ruta)
    {
        if (!Directory.Exists(ruta))
        {
            Directory.CreateDirectory(ruta);
        }
    }
}