﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApp2.Models;
//using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using Utils;
//using Microsoft.AspNet.OData.Query;

namespace NetCoreApp2.Controllers
{
    //[Authorize]
    public class UsuarioController : Controller
    {
        SecurityComponent.Usuario _dllSecuritComponentUser;

        public UsuarioController()
        {
            _dllSecuritComponentUser = new SecurityComponent.Usuario();
        }
        

        [HttpGet]
        public IActionResult Listado()
        {
            UsuarioViewModel vUsuarioViewModel = new UsuarioViewModel();
            /* ------------------------------Cargada items para el menu ------------------- */
            vUsuarioViewModel.eListaUsuario = _dllSecuritComponentUser.GetListaUsuario();  

            return View(vUsuarioViewModel);
        }


        [HttpGet]
        public List<Entities.Usuario>  Listado2()
        {
            UsuarioViewModel vUsuarioViewModel = new UsuarioViewModel();
            /* ------------------------------Cargada items para el menu ------------------- */
            vUsuarioViewModel.eListaUsuario = _dllSecuritComponentUser.GetListaUsuario();

            return vUsuarioViewModel.eListaUsuario;
        }

        /// <summary>
        /// Odata para listado de contrato
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
       // [EnableQuery]
        //[HttpGet]
        //public ActionResult<List<ESE.Usuario>> Get(ODataQueryOptions<ESE.Usuario> queryOptions)
        //{
        //    try
        //    {
        //        UsuarioViewModel vUsuarioViewModel = new UsuarioViewModel(this.User);
        //        BSE.Usuario oUsuario = new BSE.Usuario();

        //        return Ok(oUsuario.GetListaUsuarios());

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        throw ex;
        //    }
        //}

        /* ********************************************* Return view Crear ************************************************** */
        [HttpGet]
        public IActionResult Crear(int Id)
        {
            try
            {
                UsuarioViewModel vUsuarioViewModel = new UsuarioViewModel();
                
                if (Id != 0)
                {
                    vUsuarioViewModel.eUsuario = _dllSecuritComponentUser.GetEntity(Id);
                }
                else {
                    vUsuarioViewModel.eUsuario = new Entities.Usuario();
                }

                return View(vUsuarioViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///  Para la parte de carga de datos en base
        /// </summary>
        /// <param name="usuarioViewModel"></param>
        /// <returns></returns>
        /* ********************************************* Para inserar y editar ************************************************** */
        [HttpPost]
        public IActionResult Post(UsuarioViewModel vUsuarioViewModel)
        {
            try
            {
               
                if (vUsuarioViewModel.eUsuario.id_usuario != 0)
                {
                    _dllSecuritComponentUser.Modificar(vUsuarioViewModel.eUsuario);
                }
                else
                {
                    _dllSecuritComponentUser.Guardar(vUsuarioViewModel.eUsuario);
                }
            }
            catch (Exception ex)
            {

                return Ok(new { Result = false });
                throw ex;
            }
            return Ok(new { Result = true });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _dllSecuritComponentUser.Eliminar(id);

            return Ok(new { Result = true });
        }
    }
}