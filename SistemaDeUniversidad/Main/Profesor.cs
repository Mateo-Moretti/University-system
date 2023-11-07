﻿using SistemadeUniversidad.Otros;
using SistemaDeUniversidad.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUniversidad
{
    public class Profesor : Persona
    {
        private CustomList<Materia> listaMateriasInscritas = new CustomList<Materia>();

        public Profesor(string nombre, int id) : base(nombre, id)
        {

        }

        public void InscribirEnMaterias(Materia materia)
        {
            listaMateriasInscritas.Add(materia);

        }

        public CustomList<Materia> ObtenerMateriasInscritas()
        {
            return listaMateriasInscritas;
        }
    }
}