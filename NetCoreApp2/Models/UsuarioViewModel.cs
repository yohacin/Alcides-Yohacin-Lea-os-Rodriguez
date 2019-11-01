using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreApp2.Models
{
    public class UsuarioViewModel
    {
        public Entities.Usuario eUsuario { get; set; }
        public List<Entities.Usuario> eListaUsuario { get; set; }

        public UsuarioViewModel() : base()
        {

        }
        
    }
}
