using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace examen_pf.Controllers
{
    public class MedicationController(ApplicationContexte contexte) : Controller
    {
        private readonly ApplicationContexte contexte = contexte;


        public ActionResult Index()
        {
            var medications = contexte.Medications
       .Include(p => p.Prescription).ToList();

            return View(medications);
        }
        // GET: Medication/Details/5
        public ActionResult Details(int id)
        {
            var medication = contexte.Medications.Find(id);
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // GET: Medication/Create
        public ActionResult Create()
        {
            var prescriptionIds = contexte.Prescriptions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();

            // Ajoutez les ID de Prescription à ViewBag pour les rendre disponibles dans la vue
            ViewBag.PrescriptionId = prescriptionIds;
            return View();
        }

        // POST: Medication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medication medication)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexte.Medications.Add(medication);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                // Si le modèle n'est pas valide, revenez à la vue Create avec les erreurs de validation
                var prescriptionIds = contexte.Prescriptions
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() })
                    .ToList();
                ViewBag.PrescriptionId = prescriptionIds;
                return View(medication);
            }
            catch
            {
                return View();
            }
        }


        // GET: Medication/Edit/5
        public ActionResult Edit(int id)
        {
            var medication = contexte.Medications.Find(id);
            if (medication == null)
            {
                return NotFound();
            }

            // Charger la liste des ID de prescription depuis la base de données
            var prescriptionList = contexte.Prescriptions
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() })
                .ToList();
            ViewBag.PrescriptionList = prescriptionList;

            return View(medication);
        }

        // POST: Medication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Medication medication)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexte.Update(medication);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(medication);
            }
            catch
            {
                return View();
            }
        }

        // GET: Medication/Delete/5
        public ActionResult Delete(int id)
        {
            var medication = contexte.Medications.Find(id);
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // POST: Medication/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var medication = contexte.Medications.Find(id);
                if (medication == null)
                {
                    return NotFound();
                }

                contexte.Medications.Remove(medication);
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
