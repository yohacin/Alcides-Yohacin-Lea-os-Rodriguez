﻿
using System;
using System.Collections.Generic;
using System.Linq;


using Microsoft.EntityFrameworkCore;
using Interfaces;
using Utils.DataAccesComponent;

namespace MovieClubComponent
{
    public class Movie : IBussines<Entities.Movie>  
    {
        ApplicationDbContext _DBcontext;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Movie()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=bd_MovieClub;");
           // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }

        public bool Guardar(Entities.Movie eMovie)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Movie.Add(eMovie);
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

        public bool Modificar(Entities.Movie eMovie)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Movie eMovieAux = this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == eMovie.id_Movie );
                    eMovieAux.name = eMovie.name;
                    eMovieAux.id_category = eMovie.id_category ;
                    eMovieAux.year = eMovie.year ;
                    
                    this._DBcontext.Entry(eMovieAux).State = EntityState.Modified;
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
       
        public bool Eliminar(int id_Movie)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Movie eMovieAux = this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == id_Movie);
                    this._DBcontext.Movie.Remove(eMovieAux); 

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
        #endregion

        #region metodos get, listado, etc
        public Entities.Movie GetEntity(int id_Movie)
        {
            try
            {
                return this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == id_Movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IQueryable<Entities.Movie> GetLista()
        {
            try
            {
                return this._DBcontext.Movie.OrderByDescending(e => e.id_Movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Entities.Actor> GetMovieActors(int id_movie)
        {
            try
            {
                  return this._DBcontext.Actor
                        .FromSql($@" SELECT  Actor.* from Actor 
                                            join MoviesxActor on (Actor.id_actor = MoviesxActor.id_Actor )
	                                        join Movie on (MoviesxActor.id_Movie = Movie.id_Movie)
                                        WHERE Movie.id_Movie =   {id_movie} ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        



        #endregion



    }



}
