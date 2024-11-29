using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace examen_pf.Controllers
{
    public class PharmacistController : Controller
    {
        private readonly ApplicationContexte _context;

        public PharmacistController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Pharmacist/Index
        /// <summary>
        /// Affiche la liste des pharmaciens.
        /// </summary>
        /// <returns>Vue avec la liste des pharmaciens.</returns>
        public IActionResult Index()
        {
            // Récupérer la liste des pharmaciens depuis la base de données
            var pharmacists = _context.Pharmacists.ToList();

            // Passer la liste des pharmaciens à la vue pour l'affichage
            return View(pharmacists);
        }

        // GET: Pharmacist/Details/5
        /// <summary>
        /// Affiche les détails d'un pharmacien spécifique.
        /// </summary>
        /// <param name="id">ID du pharmacien à afficher.</param>
        /// <returns>Vue avec les détails du pharmacien.</returns>
        public IActionResult Details(int id)
        {
            // Rechercher le pharmacien par son ID dans la base de données
            var pharmacist = _context.Pharmacists.FirstOrDefault(p => p.Id == id);

            // Vérifier si le pharmacien existe
            if (pharmacist == null)
            {
                return NotFound(); // Retourner une erreur 404 si le pharmacien n'est pas trouvé
            }

            // Passer le pharmacien à la vue pour les détails
            return View(pharmacist);
        }

        // GET: Pharmacist/Create
        /// <summary>
        /// Affiche le formulaire de création d'un nouveau pharmacien.
        /// </summary>
        /// <returns>Vue avec le formulaire de création.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacist/Create
        /// <summary>
        /// Traite la soumission du formulaire de création d'un nouveau pharmacien.
        /// </summary>
        /// <param name="pharmacist">Le pharmacien à créer.</param>
        /// <returns>Redirection vers l'index des pharmaciens en cas de succès, sinon retourne le formulaire de création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pharmacist pharmacist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Pharmacists.Add(pharmacist);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(pharmacist);
            }
            catch
            {
                return View();
            }
        }

        
    }
}

