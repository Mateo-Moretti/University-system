using System;
using System.Collections.Generic;
using SistemadeUniversidad.Contracts;
using SistemadeUniversidad.Contracts.Models;

public class Program
{
    static Manager manager = new Manager();
  
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(" ");
            Console.WriteLine("///////////////////////////////////////////////////////////////////// ");
            Console.WriteLine("MENU:");

            Console.WriteLine(" ");
            Console.WriteLine("Ingresar datos: ");

            Console.WriteLine("1. Agregar Profesor");
            Console.WriteLine("2. Agregar Alumno");
            Console.WriteLine("3. Crear Materia");

            Console.WriteLine(" ");
            Console.WriteLine("Funciones: ");

            Console.WriteLine("4. Asignar Materia a Profesor");
            Console.WriteLine("5. Inscribir Alumno en Materia");
            Console.WriteLine("6. Desanotar Alumno de Materia");

            Console.WriteLine(" ");
            Console.WriteLine("Informacion: ");

            Console.WriteLine("7. Datos de Profesor"); //Quienes son sus alumnos
            Console.WriteLine("8. Datos de Alumno"); //Quienes son sus profesores
            Console.WriteLine("9. Datos de Materia"); //Quienes son sus alumnos y quien su profesor

            Console.WriteLine(" ");

            Console.WriteLine("10. Salir del programa");

            Console.WriteLine(" ");

            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProfesor(dataSource);
                    break;

                case "2":
                    AgregarAlumno();
                    break;

                case "3":
                    CrearMateria();                  
                    break;

                case "4":
                    InscribirProfesorEnMateria();
                    break;

                case "5":
                    InscribirAlumnoenMateria();
                    break;

                case "6":
                    DesanotarAlumno();
                    break;

                case "7":
                    DatosProfesor();
                    break;

                case "8":
                    DatosAlumno();
                    break;

                case "9":
                    DatosMateria();
                    break;

                case "10":
                    return;

                default:
                    Console.WriteLine("Opcion no válida.");
                    break;
            }           
        }

        #region CREADORES
        static void AgregarProfesor(NpgsqlDataSource dataSource)
        {
            manager.CrearProfesor(dataSource);           
        }
    
        static void AgregarAlumno()
        {
            manager.CrearAlumnos();
        }
        
        static void CrearMateria()
        {           
            manager.CrearMaterias();                       
        }
        #endregion

        #region INSCRIPTORES
        static void InscribirAlumnoenMateria()
        {            
            Console.Write("Nombre del alumno: ");
            string? nombreAlumno = Console.ReadLine();

            Console.Write("ID del alumno: ");
            string? inputAlumno = Console.ReadLine();
            int? idAlumno = int.Parse(inputAlumno);

            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int? idMateria = int.Parse(inputMateria);

            Alumno? alumno = manager.ChequeoAlumnoExistente(nombreAlumno, idAlumno);
            Materia? materia = manager.ChequeoMateriaExistente(nombreMateria, idMateria);

            if (alumno != null && materia != null)
            {
               manager.InscribirAlumnoEnMateria(alumno, materia);
            }
            else
            {
                if (alumno == null)
                {
                    Console.WriteLine("El alumno ingresado no existe.");
                }

                if (materia == null)
                {
                    Console.WriteLine("La materia ingresada no existe.");
                }
            }
        }

        static void InscribirProfesorEnMateria()
        {
            Console.Write("Nombre del profesor: ");
            string? nombreProfesor = Console.ReadLine();

            Console.Write("ID del profesor: ");
            string? inputProfesor = Console.ReadLine();
            int? idProfesor = int.Parse(inputProfesor);

            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int? idMateria = int.Parse(inputMateria);

            Profesor? profesor = manager.ChequeoProfesorExistente(nombreProfesor, idProfesor);
            Materia? materia = manager.ChequeoMateriaExistente(nombreMateria, idMateria);

            if (profesor != null && materia != null)
            {
                manager.InscribirProfesorEnMateria(profesor, materia);
            }
            else
            {
                if (profesor == null)
                {
                    Console.WriteLine("El profesor ingresado no existe.");
                }

                if (materia == null)
                {
                    Console.WriteLine("La materia ingresada no existe.");
                }
            }
        }
        #endregion

        static void DesanotarAlumno()
        {

        }

        static void DatosProfesor()
        {

        }

        static void DatosAlumno()
        {

        }

        static void DatosMateria()
        {            
            
        }
    
    }
}

