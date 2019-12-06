using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProizvodJSONController : Controller
    {
        private Context db = new Context();

        // GET: ProizvodJSON
        public ActionResult Index()
        {
            string file = Server.MapPath("~/App_Data/cuvanje.json");
            string Json = System.IO.File.ReadAllText(file);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var lista = ser.Deserialize<List<Proizvod>>(Json);
            return View(lista);
        }

        // GET: ProizvodJSON/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProizvodJSON/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                string file = Server.MapPath("~/App_Data/cuvanje.json");
                string Json = System.IO.File.ReadAllText(file);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                var lista = ser.Deserialize<List<Proizvod>>(Json);
                var niz = lista.ToArray();

                int slId = 0;
                for (int i = 0; i < niz.Count(); i++)
                    if (niz[i].Id > slId)
                        slId = niz[i].Id;
                proizvod.Id = slId + 1;

                lista.Add(proizvod);
                

                string jsondata = new JavaScriptSerializer().Serialize(lista);
                string path = Server.MapPath("~/App_Data/");
                
                System.IO.File.WriteAllText(path + "cuvanje.json", jsondata);

                return RedirectToAction("Index");
            }

            return View(proizvod);
        }

        // GET: ProizvodJSON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string file = Server.MapPath("~/App_Data/cuvanje.json");
            string Json = System.IO.File.ReadAllText(file);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var lista = ser.Deserialize<List<Proizvod>>(Json);
            var niz = lista.ToArray();

            Proizvod proizvod = null;
            for (int i = 0; i < niz.Count(); i++)
            {
                if (niz[i].Id == id)
                {
                    proizvod = niz[i];
                    break;
                }
            }
            return View(proizvod);
        }

        // POST: ProizvodJSON/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                string file = Server.MapPath("~/App_Data/cuvanje.json");
                string Json = System.IO.File.ReadAllText(file);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                var lista = ser.Deserialize<List<Proizvod>>(Json);
                var niz = lista.ToArray();

                for (int i = 0; i < niz.Count(); i++)
                {
                    if (niz[i].Id == proizvod.Id)
                    {
                        niz[i].Naziv = proizvod.Naziv;  niz[i].Opis = proizvod.Opis;
                        niz[i].Kategorija = proizvod.Kategorija;    niz[i].Proizvodjac = proizvod.Proizvodjac;
                        niz[i].Dobavljac = proizvod.Dobavljac;      niz[i].Cena = proizvod.Cena;
                        break;
                    }
                }

                string jsondata = new JavaScriptSerializer().Serialize(lista);
                string path = Server.MapPath("~/App_Data/");

                System.IO.File.WriteAllText(path + "cuvanje.json", jsondata);
                return RedirectToAction("Index");
            }
            return View(proizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
