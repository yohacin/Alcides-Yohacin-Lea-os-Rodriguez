﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IBussines<T>
    {
        bool Guardar(T eEntidad);

        bool Modificar(T eEntidad);

        bool Eliminar(int id);

        #region metodos get, listado, etc
        T GetEntity(int id);

        IQueryable<T> GetLista();

        #endregion
    }
}