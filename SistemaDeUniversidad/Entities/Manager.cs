using SistemadeUniversidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace SistemaDeUniversidad.Entities
{

    public class Manager
    {
        public List<Profesor> listaProfesor;
        public List<Alumno> listaAlumnos;
        public List<Materia> listaMaterias;

        private int idContadorMaterias = 1;
        private int idContadorAlumnos = 1;
        private int idContadorProfesores = 1;

        public Manager()
        {
            listaProfesor = new List<Profesor>();
            listaAlumnos = new List<Alumno>();
            listaMaterias = new List<Materia>();
        }

        #region CREADORES

        //ESTO SE ENCARGA DE CREAR PROFESORES
        public async void CrearProfesor(NpgsqlDataSource dataSource)
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

            using var command = dataSource.CreateCommand($"INSERT INTO universidad.profesores(nombre) VALUES ('{nombre}')");
            using var inserter = command.ExecuteNonQueryAsync();

            Profesor nuevoProfesor = new Profesor(nombre, idContadorProfesores);
            idContadorProfesores++;
            listaProfesor.Add(nuevoProfesor);

            /*
            Profesor nuevoProfesor = new Profesor(nombre, idContadorProfesores);
            await using var cmd = new NpgsqlCommand($"INSERT INTO universidad.profesores(nombre) VALUES ('{nombre}')")
            {
                Parameters =
                {
                    new() {Value = nuevoProfesor.nombre}
                }
            };

            await cmd.ExecuteNonQueryAsync();*/

            Console.WriteLine($"Profesor {nuevoProfesor.nombre} con el id {nuevoProfesor.id} agregado.");
            Console.WriteLine($"{listaProfesor.Count()} es el numero total de items en la lista de profesores");
        }
        
        //ESTO SE ENCARGA DE CREAR ALUMNOS
        public void CrearAlumnos()
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

            Alumno nuevoAlumno = new Alumno(nombre, idContadorAlumnos);
            idContadorAlumnos++;
            listaAlumnos.Add(nuevoAlumno);
            Console.WriteLine($"Alumno {nuevoAlumno.nombre} con el id {nuevoAlumno.id} agregado.");
            Console.WriteLine($"{listaAlumnos.Count()} es el numero total de items en la lista de alumnos");
        }

        //ESTO SE ENCARGA DE CREAR MATERIAS
        public void CrearMaterias()
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

            Materia nuevaMateria = new Materia(nombre, idContadorMaterias);
            idContadorMaterias++;
            listaMaterias.Add(nuevaMateria);
            Console.WriteLine($"Materia {nuevaMateria.nombre} con id {nuevaMateria.id} agregada.");
            Console.WriteLine($"{listaMaterias.Count()} es el numero total de items en la lista de materias");
        }
        #endregion

        #region CHEQUEADORES

        //Chequea que el profesor dado por consola existe en la lista
        public Profesor? ChequeoProfesorExistente(string? nombreIngresado, int? idProfesor)
        {
            foreach (Profesor profesor in listaProfesor)
            {
                if (profesor != null)
                {
                    if (profesor.nombre == nombreIngresado && profesor.id == idProfesor)
                    {
                        return profesor;
                    }
                }
            }
            return null;
        }

        //Chequea que el alumno dado por consola existe en la lista
        public Alumno? ChequeoAlumnoExistente(string? nombreIngresado, int? idAlumno)
        {            
            foreach (Alumno alumno in listaAlumnos)
            {
                if(alumno != null)
                {
                    if (alumno.nombre == nombreIngresado && alumno.id == idAlumno)
                    {
                        return alumno; 
                    }
                }
            }
            return null; 
        }

        //Chequea que la materia dado por consola existe en la lista
        public Materia? ChequeoMateriaExistente(string? nombreIngresado, int? idMateria)
        {
            foreach (Materia materia in listaMaterias)
            {
                if(materia != null)
                {
                    if (materia.nombre == nombreIngresado && materia.id == idMateria)
                    {
                        return materia; 
                    }
                }
            }
            return null; 
        }
        #endregion

        #region INSCRIPTORES

        public bool InscribirAlumnoEnMateria(Alumno alumno, Materia materia)
        {
            //Me fijo si la materia existe
            if (!listaMaterias.Contains(materia))
            {
                Console.WriteLine($"La materia {materia.nombre} no existe");
                return false;
            }

            //Fijarse el limite de materias inscritas
            if (alumno.ObtenerMateriasInscritas().Count() >= 2)
            {
                Console.WriteLine($"El alumno {alumno.nombre} ya esta inscrito en 2 materias.");
                return false;
            }

            alumno.InscribirEnMaterias(materia);
            Console.WriteLine($"El alumno {alumno.nombre} se ha inscrito en la materia {materia.nombre}");
            return true;
        }

        public bool InscribirProfesorEnMateria(Profesor profesor, Materia materia)
        {
            //Me fijo si la materia existe
            if (!listaMaterias.Contains(materia))
            {
                Console.WriteLine($"La materia {materia.nombre} no existe");
                return false;
            }

            //Fijarse el limite de materias inscritas
            if (profesor.ObtenerMateriasInscritas().Count() >= 1)
            {
                Console.WriteLine($"El profesor {profesor.nombre} ya esta inscrito en 1 materia.");
                return false;
            }

            profesor.InscribirEnMaterias(materia);
            Console.WriteLine($"El profesor {profesor.nombre} se ha inscrito en la materia {materia.nombre}");
            return true;
        }

        internal void CrearProfesor(NpgsqlCommand command)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
