using System;
using System.Collections.Generic;
using SistemadeUniversidad.Contracts;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Persistance;
using SistemadeUniversidad;
using SistemaDeUniversidad.Services;
using SistemaDeUniversidad.Contracts.Services;

public class Program
{
    /*
    public static Dictionary<int, Profesor> diccionarioProfesor = new Dictionary<int, Profesor>();
    public static Dictionary<int, Student> diccionarioAlumnos = new Dictionary<int, Student>();
    public static Dictionary<int, Course> diccionarioMaterias = new Dictionary<int, Course>();
    */

    static void Main()
    {
        /*
        
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
                    //AgregarProfesor();
                    break;

                case "2":
                    //AgregarAlumno();
                    break;

                case "3":
                    //CrearMateria();                  
                    break;

                case "4":
                    InscribirProfesorEnMateria();
                    break;

                case "5":
                    InscribirAlumnoEnMateria();
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
        static void AgregarProfesor()
        {
            string? nombre = null;

            while (string.IsNullOrEmpty(nombre))
            {
                Console.Write("Nombre del profesor: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("Nombre del profesor no puede estar vacio");
                }
            }

            Profesor nuevoProfesor = new Profesor(nombre, idContadorProfesores);
            diccionarioProfesor.Add(idContadorProfesores, nuevoProfesor);

            DataBase.Profesores.CreateAsync(nuevoProfesor, nombre, idContadorProfesores);

            idContadorProfesores++;

            Console.WriteLine($"Profesor {nuevoProfesor.nombre} con el id {nuevoProfesor.id} agregado.");
        }
    
        static void AgregarAlumno()
        {
            string? nombre = null;

            while (string.IsNullOrEmpty(nombre))
            {
                Console.Write("Nombre del alumno: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("Nombre del alumno no puede estar vacio");
                }
            }

            Student nuevoAlumno = new Student(nombre, idContadorAlumnos);
            diccionarioAlumnos.Add(idContadorAlumnos, nuevoAlumno);

            DataBase.Alumnos.CreateAsync(nuevoAlumno, nombre, idContadorAlumnos);

            idContadorAlumnos++;

            Console.WriteLine($"Alumno {nuevoAlumno.nombre} con el id {nuevoAlumno.id} agregado.");
        }
        
        static void CrearMateria()
        {
            string? nombre = null;

            while (string.IsNullOrEmpty(nombre))
            {
                Console.Write("Nombre de la materia: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("Nombre de materia no puede estar vacio");
                }
            }

            Course nuevaMateria = new Course(nombre, idContadorMaterias);
            diccionarioMaterias.Add(idContadorMaterias, nuevaMateria);

            DataBase.Materias.CreateAsync(nuevaMateria, nombre, idContadorMaterias);

            idContadorMaterias++;

            Console.WriteLine($"Materia {nuevaMateria.nombre} con id {nuevaMateria.id} agregada.");
        }
        #endregion
        

        
        #region INSCRIPTORES
        static void InscribirAlumnoEnMateria()
        {            
            Console.Write("Nombre del alumno: ");
            string nombreAlumno = Console.ReadLine();

            Console.Write("ID del alumno: ");
            string? inputAlumno = Console.ReadLine();
            int idAlumno = int.Parse(inputAlumno);

            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int idMateria = int.Parse(inputMateria);

            Student? alumno = ChequeoAlumnoExistente(nombreAlumno, idAlumno);
            Course? materia = ChequeoMateriaExistente(nombreMateria, idMateria);
            CourseService materiaService = new CourseService();

            StudentService alumnoSerice = new StudentService();

            if (alumno != null && materia != null)
            {
                if (!diccionarioMaterias.ContainsKey(idMateria))
                {
                    Console.WriteLine($"La materia {materia.Name} no existe");
                }
                if (alumnoSerice.ObtenerMateriasInscritas().Count >= 2)
                {
                    Console.WriteLine($"El alumno {alumno.Name} ya esta inscrito en 2 materias.");
                }
                if (alumnoSerice.CheckYaInscripto(materia) is true)
                {
                    Console.WriteLine($"El alumno {alumno.Name} ya esta inscrito en esta materia.");
                }
                else
                {
                    alumnoSerice.InscribirEnMaterias(materia);
                    materiaService.InscribirAlumno(alumno);
                    //DataBase.Alumnos.InscribirAMateria(idAlumno, idMateria);
                    Console.WriteLine($"El alumno {alumno.Name} se ha inscrito en la materia {materia.Name}");
                }
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
            int idProfesor = int.Parse(inputProfesor);

            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int idMateria = int.Parse(inputMateria);

            Profesor? profesor = ChequeoProfesorExistente(nombreProfesor, idProfesor);
            Course? materia = ChequeoMateriaExistente(nombreMateria, idMateria);
            CourseService materiaService = new CourseService();
            ProfesorService profesorService = new ProfesorService();

            if (profesor != null && materia != null)
            {
                if (!diccionarioMaterias.ContainsKey(idMateria))
                {
                    Console.WriteLine($"La materia {materia.Name} no existe");
                }
                if (profesorService.ObtenerMateriasInscritas().Count >= 1)
                {
                    Console.WriteLine($"El profesor {profesor.Name} ya esta inscrito en 1 materia.");
                }
                if (profesorService.CheckYaInscripto(materia) is true)
                {
                    Console.WriteLine($"El profesor {profesor.Name} ya esta inscrito en esta materia.");
                }
                else
                {
                    profesorService.InscribirEnMaterias(materia);
                    materiaService.InscribirProfesor(profesor);
                    //DataBase.Profesores.InscribirAMateria(idProfesor, idMateria);
                    Console.WriteLine($"El profesor {profesor.Name} se ha inscrito en la materia {materia.Name}");
                }
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
        

        
        #region DESINSCRIPTORES
        static void DesanotarAlumno()
        {
            Console.Write("Nombre del alumno: ");
            string nombreAlumno = Console.ReadLine();

            Console.Write("ID del alumno: ");
            string? inputAlumno = Console.ReadLine();
            int idAlumno = int.Parse(inputAlumno);

            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int idMateria = int.Parse(inputMateria);

            Student? alumno = ChequeoAlumnoExistente(nombreAlumno, idAlumno);
            Course? materia = ChequeoMateriaExistente(nombreMateria, idMateria);
            CourseService materiaService = new CourseService();
            StudentService alumnoSerice = new StudentService();


            if (alumno != null && materia != null)
            {
                if (diccionarioMaterias.ContainsKey(idMateria))
                {
                    Console.WriteLine($"La materia {materia.Name} no existe");
                }
                alumnoSerice.DesinscribirDeMaterias(materia);
                materiaService.DesinscribirAlumnoDeMaterias(alumno);
                //DataBase.Alumnos.DesinscribirDeMateria(idAlumno, idMateria);
                Console.WriteLine($"El alumno {alumno.Name} se ha desinscrito de la materia {materia.Name}");
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
        #endregion
        

        #region CHECKERS
        static Profesor? ChequeoProfesorExistente(string? nombreIngresado, int? idProfesor)
        {
            foreach (var profesorEntry in diccionarioProfesor)
            {
                var profesor = profesorEntry.Value;

                if (profesor != null && profesor.Name == nombreIngresado && profesor.Id == idProfesor)
                {
                    return profesor;
                }
            }
            return null;
        }

        static Student? ChequeoAlumnoExistente(string? nombreIngresado, int? idAlumno)
        {
            foreach (var alumnoEntry in diccionarioAlumnos)
            {
                var alumno = alumnoEntry.Value;

                if (alumno != null && alumno.Name == nombreIngresado && alumno.Id == idAlumno)
                {
                    return alumno;
                }
            }
            return null;
        }

        static Course? ChequeoMateriaExistente(string? nombreIngresado, int? idMateria)
        {
            foreach (var materiaEntry in diccionarioMaterias)
            {
                var materia = materiaEntry.Value;

                if (materia != null && materia.Name == nombreIngresado && materia.Id == idMateria)
                {
                    return materia;
                }
            }
            return null;
        }
        #endregion

        
        #region DATOS
        static void DatosProfesor()
        {
            Console.Write("Nombre del profesor: ");
            string? nombreProfesor = Console.ReadLine();

            Console.Write("ID del profesor: ");
            string? inputProfesor = Console.ReadLine();
            int idProfesor = int.Parse(inputProfesor);

            Profesor? profesor = ChequeoProfesorExistente(nombreProfesor, idProfesor);
            CourseService materiaService = new CourseService();
            ProfesorService profesorService = new ProfesorService();

            if (profesor != null)
            {
                List<Course> materiasInscritas = profesorService.ObtenerMateriasInscritas();

                if (materiasInscritas.Count > 0)
                {
                    Console.WriteLine($"Materias de {profesor.Name}:");
                    foreach (var materia in materiasInscritas)
                    {
                        Console.WriteLine($"ID: {materia.Id}, Nombre: {materia.Name}");

                        Console.WriteLine($"Alumnos inscritos en {materia.Name}:");
                        foreach (var alumno in materiaService.ObtenerAlumnosInscritos())
                        {
                            Console.WriteLine($"ID: {alumno.Id}, Nombre: {alumno.Name}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"El profesor {profesor.Name} no está inscrito en ninguna materia.");
                }
            }
            else
            {
                Console.WriteLine("El profesor ingresado no existe.");
            }
        }

        static void DatosAlumno()
        {
            Console.Write("Nombre del alumno: ");
            string? nombreAlumno = Console.ReadLine();

            Console.Write("ID del alumno: ");
            string? inputAlumno = Console.ReadLine();
            int idAlumno = int.Parse(inputAlumno);

            Student? alumno = ChequeoAlumnoExistente(nombreAlumno, idAlumno);
            CourseService materiaService = new CourseService();
            StudentService alumnoSerice = new StudentService();

            if (alumno != null)
            {
                List<Course> materiasInscritas = alumnoSerice.ObtenerMateriasInscritas();

                if (materiasInscritas.Count > 0)
                {
                    Console.WriteLine($"Materias que {alumno.Name} cursa:");
                    foreach (var materia in materiasInscritas)
                    {
                        Console.WriteLine($"ID: {materia.Id}, Nombre: {materia.Name}");

                        Console.WriteLine($"Profesor de la materia {materia.Name}:");
                        foreach (var profesor in materiaService.ObtenerProfesoresInscritos())
                        {
                            Console.WriteLine($"ID: {profesor.Id}, Nombre: {profesor.Name}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"El alumno {alumno.Name} no está inscrito en ninguna materia.");
                }
            }
            else
            {
                Console.WriteLine("El alumno ingresado no existe.");
            }
        }

        static void DatosMateria()
        {
            Console.Write("Nombre de la materia: ");
            string? nombreMateria = Console.ReadLine();

            Console.Write("ID de la materia: ");
            string? inputMateria = Console.ReadLine();
            int idMateria = int.Parse(inputMateria);

            Course? materia = ChequeoMateriaExistente(nombreMateria, idMateria);
            CourseService materiaService = new CourseService();

            if (materia != null)
            {
                List<Student> alumnosInscriptos = materiaService.ObtenerAlumnosInscritos();
                List<Profesor> profesorInscriptos = materiaService.ObtenerProfesoresInscritos();

                if (alumnosInscriptos.Count > 0)
                {
                    Console.WriteLine($"Alumnos cursan {materia.Name}:");
                    foreach (var alumnos in alumnosInscriptos)
                    {
                        Console.WriteLine($"ID: {alumnos.Id}, Nombre: {alumnos.Name}");                                       
                    }
                }
                else
                {
                    Console.WriteLine($"La materia {materia.Name} no está siendo cursada por ningun alumno.");
                }

                if(profesorInscriptos.Count > 0)
                {
                    Console.WriteLine($"Profesor que da {materia.Name}:");
                    foreach (var profesor in materiaService.ObtenerProfesoresInscritos())
                    {
                        Console.WriteLine($"ID: {profesor.Id}, Nombre: {profesor.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"La materia {materia.Name} no está siendo dada por ningun profesor.");
                }
            }
            else
            {
                Console.WriteLine("La materia ingresada no existe.");
            }
        }
        #endregion
        
        */
    }

    
}

