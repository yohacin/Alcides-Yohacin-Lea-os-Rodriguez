
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Usuario
    {

         ApplicationDbContext  _DBcontext ;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Usuario()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=db_facturacion;");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);
            
        }


        public bool Guardar(Entities.Usuario eUsuario)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Usuario.Add(eUsuario);
                    this._DBcontext.SaveChanges();

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public bool Modificar(Entities.Usuario eUsuario)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Usuario eUsuarioAux = this._DBcontext.Usuario.FirstOrDefault(e => e.id_usuario == eUsuario.id_usuario);
                    eUsuarioAux.nombre = eUsuario.nombre;
                    eUsuarioAux.correo = eUsuario.correo;
                    eUsuarioAux.user_name = eUsuario.user_name;
                    eUsuarioAux.contrasena = eUsuario.contrasena;
                    eUsuarioAux.telefono = eUsuario.telefono;
                    
                    this._DBcontext.Entry(eUsuarioAux).State = EntityState.Modified;
                    this._DBcontext.SaveChanges();

                   

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Usuario eUsuario = this.GetUsuario(id);

                    //oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        #endregion

        #region metodos get, listado, etc
        public Entities.Usuario GetUsuario(int usuarioId)
        {
            try
            {
                return this._DBcontext.Usuario.FirstOrDefault(e => e.id_usuario == usuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Entities.Usuario> GetListaUsuarios()
        {
            try
            {
                return this._DBcontext.Usuario.OrderByDescending(e => e.id_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.Usuario> GetListaUsuario()
        {
            try
            {
                return this._DBcontext.Usuario.OrderByDescending(e => e.id_usuario).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public Entities.Usuario Login(string correo, string contrasena)
        {
            try
            {
                Entities.Usuario eUsuario = _DBcontext.Usuario.Where(u => u.user_name == correo && u.contrasena == contrasena).Single();
                return eUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
