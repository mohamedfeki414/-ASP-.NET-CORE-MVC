using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;

namespace examen_pf.Controllers
{
    public class PatientController(ApplicationContexte contexte) : Controller
    {
        private readonly ApplicationContexte contexte = contexte;
        

        public ActionResult Index()
        {
            return View(contexte.Patients.ToList());
        }
        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            var patient = contexte.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexte.Patients.Add(patient);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(patient);
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            var patient = contexte.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexte.Update(patient);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(patient);
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            var patient = contexte.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var patient = contexte.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }

                contexte.Patients.Remove(patient);
                contexte.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }
    }
}


