using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace CertfTaller.Controllers
{
    public class PeliculaController : Controller
    {
        //private Entities db = new Entities();

        // GET: Pelicula
        public ActionResult Index()
        {
            return View(PeliculaBLL.List());
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = PeliculaBLL.Get(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelicula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pel,nombre_peli,fecha_lanzamiento_peli,categoria_pel,duracion_peli")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                //db.Peliculas.Add(pelicula);
                //db.SaveChanges();
                PeliculaBLL.Create(pelicula);
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = PeliculaBLL.Get(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pel,nombre_peli,fecha_lanzamiento_peli,categoria_pel,duracion_peli")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(pelicula).State = EntityState.Modified;
                //db.SaveChanges();
                PeliculaBLL.Update(pelicula);
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = PeliculaBLL.Get(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ////Pelicula pelicula = db.Peliculas.Find(id);
            //db.Peliculas.Remove(pelicula);
            //db.SaveChanges();
            PeliculaBLL.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
