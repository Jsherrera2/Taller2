using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class PeliculaBLL
    {
        public static void Create(Pelicula a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Peliculas.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static Pelicula Get(int? id)
        {
            Entities db = new Entities();
            return db.Peliculas.Find(id);
        }


        public static void Update(Pelicula alumno)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Peliculas.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pelicula alumno = db.Peliculas.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }

            }


        }


        public static List<Pelicula> List()
        {
            Entities db = new Entities(); //Instancia del Contexto

            /*List<Alumno> alumnos = db.Alumnoes.ToList();
            List<Alumno> resultado = new List<Alumno>();
            foreach (Alumno a in alumnos)
            {
                if (a.sexo =="M")
                {
                    resultado.Add(a);

                }
            }
            return resultado;*/

            //return db.Alumnoes.Where(x => x.sexo == "M").ToList();


            return db.Peliculas.ToList();//SQL-> SELECT * FROM db Alumno
            //los metodos del EntityFrameword se denomina Linq, y la evaluacion de condicion lambda

        }

    }
}
