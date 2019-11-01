using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace Facturacion.Models
{
    public class ViewModelBase
    {
        // public List<BES.Module> colModules { get; set; }

        public string NombreUsuario { get; }

        public string UsuarioImagen { get; }

        public string Contrasena { get; }

        public string Correo { get; }

        public string NombreEmpresa { get; }

        public string EmpresaImagen { get; }


        public int numeroFlujos { get; }




        public string NombreRol { get; }

        public int idUsuario { get; }

        public int idEmpresa { get; }

        public bool muchas_empresas { get; }


        public List<object> menuItems { get; set; }



        public ViewModelBase(ClaimsPrincipal User)
        {
            //Opteniendo datos de la cookie


            //NombreUsuario = User.GetClaimValue("nombre_usuario");
            //Contrasena = User.GetClaimValue("contrasena");
            //Correo = User.GetClaimValue("correo");
            //UsuarioImagen = User.GetClaimValue("imagen_usuario");
            //NombreRol = "Role";

            //NombreEmpresa = User.GetClaimValue("empresa");
            //EmpresaImagen = User.GetClaimValue("imagen_empresa");

            //numeroFlujos = Convert.ToInt16(User.GetClaimValue("numero_flujos"));
            
            //idUsuario = Convert.ToInt16(User.GetClaimValue("id_usuario"));
            //idEmpresa = Convert.ToInt16(User.GetClaimValue("id_empresa"));
            //muchas_empresas = Convert.ToBoolean(User.GetClaimValue("muchas_empresas"));

            menuItems = new List<object>();

        }


        public ViewModelBase()
        {
        }
    }
}
