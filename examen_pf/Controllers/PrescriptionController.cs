using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace examen_pf.Controllers
{
    public class PrescriptionController(ApplicationContexte contexte) : Controller
    {
        private readonly ApplicationContexte contexte=contexte;
     

        
        // GET: Prescription/Index
        public ActionResult Index()
        {
            var prescriptions = contexte.Prescriptions
        .Include(p => p.Pharmacist)
        .Include(p => p.Patient)
        .ToList();

            return View(prescriptions);
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int id)
        {
            // Recherche une prescription par son ID et l'affiche dans la vue Details
            var prescription = contexte.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        // GET: Prescription/Create
        public ActionResult Create()
        {
            // Affiche le formulaire de création d'une nouvelle prescription
            var pharmacistIds = contexte.Pharmacists.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
            var patientIds = contexte.Patients.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();

            ViewBag.PharmacistId = pharmacistIds;
            ViewBag.PatientId = patientIds;

            return View();
        }

        // POST: Prescription/Create
        // POST: Prescription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prescription prescription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Ajoute la nouvelle prescription à la base de données et redirige vers Index si valide
                    contexte.Prescriptions.Add(prescription);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                // Rechargez les listes déroulantes des ID de pharmacien et de patient en cas d'échec de validation
                ViewBag.PharmacistId = contexte.Pharmacists.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
                ViewBag.PatientId = contexte.Patients.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();

                return View(prescription);
            }
            catch (Exception ex)
            {
                // Gérez l'exception ou affichez-la pour le débogage
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }


        // GET: Prescription/Edit/5
        public ActionResult Edit(int id)
        {// Recherche une prescription par son ID et affiche le formulaire de modification
            var prescription = contexte.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound();
            }

            // Charger la liste des ID de pharmacien et de patient depuis la base de données
            var pharmacistIds = contexte.Pharmacists.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
            var patientIds = contexte.Patients.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();

            // Assigner les listes à la ViewBag
            ViewBag.PharmacistIdList = pharmacistIds;
            ViewBag.PatientIdList = patientIds;

            // Passer la prescription à la vue pour l'édition
            return View(prescription);
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Prescription prescription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Met à jour la prescription dans la base de données et redirige vers Index si valide
                    contexte.Update(prescription);
                    contexte.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(prescription);
            }
            catch
            {
                return View();
            }
        }

        // GET: Prescription/Delete/5
        public ActionResult Delete(int id)
        {
            // Recherche une prescription par son ID et affiche la vue de confirmation de suppression
            var prescription = contexte.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Supprime la prescription de la base de données et redirige vers Index
            var prescription = contexte.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound(); // Ou rediriger vers une autre vue pour gérer le cas où la prescription n'est pas trouvée
            }
            contexte.Prescriptions.Remove(prescription);
            contexte.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
    

}

