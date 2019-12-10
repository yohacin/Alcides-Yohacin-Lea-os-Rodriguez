
using System;
using System.Collections.Generic;
using System.Linq;


using Microsoft.EntityFrameworkCore;
using Interfaces;
using Utils.DataAccesComponent;

namespace MovieClubComponent
{
    public class Actor : IBussines<Entities.Actor>
    {
        ApplicationDbContext _DBcontext;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Actor()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=bd_MovieClub;");
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }

        public bool Guardar(Entities.Actor  eActor)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Actor.Add(eActor);
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

        public bool Modificar(Entities.Actor eActor)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Actor eActorAux = this._DBcontext.Actor.FirstOrDefault(e => e.id_Actor == eActor.id_Actor);
                    eActorAux.Name  = eActor.Name;
                    
                    this._DBcontext.Entry(eActorAux).State = EntityState.Modified;
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

        public bool Eliminar(int id_Actor)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Actor eActorAux = this._DBcontext.Actor.FirstOrDefault(e => e.id_Actor == id_Actor);
                    this._DBcontext.Actor.Remove(eActorAux);

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
        public Entities.Actor GetEntity(int id_Actor)
        {
            try
            {
                return this._DBcontext.Actor.FirstOrDefault(e => e.id_Actor == id_Actor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IQueryable<Entities.Actor> GetLista()
        {
            try
            {
                return this._DBcontext.Actor.OrderBy(p => p.id_Actor  );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IQueryable<Entities.Movie> GetMovies(int id_Actor)
        {
            try
            {
                return this._DBcontext.Movie 
                      .FromSql($@" SELECT  Movie.* from Actor 
                                          join MoviesxActor on (Actor.id_Actor = MoviesxActor.id_Actor )
	                                      join Movie on (MoviesxActor.id_Movie = Movie.id_Movie )             
                                   WHERE Actor.id_Actor = {id_Actor} ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion


    }
}
