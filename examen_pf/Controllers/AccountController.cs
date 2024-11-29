using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace examen_pf.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContexte _context;

        public AccountController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Account/Index
        /// <summary>
        /// Affiche la liste des comptes.
        /// </summary>
        /// <returns>Vue avec la liste des comptes.</returns>
        public IActionResult Index()
        {
            // Récupérer la liste des comptes depuis la base de données
            var accounts = _context.Accounts.ToList();

            // Passer la liste des comptes à la vue pour l'affichage
            return View(accounts);
        }

        // GET: Account/Details/5
        /// <summary>
        /// Affiche les détails d'un compte spécifique.
        /// </summary>
        /// <param name="id">ID du compte à afficher.</param>
        /// <returns>Vue avec les détails du compte.</returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Rechercher le compte dans la base de données
            var account = _context.Accounts.FirstOrDefault(m => m.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            // Passer le compte à la vue pour l'affichage des détails
            return View(account);
        }

        // Autres actions comme Create, Edit, Delete peuvent être ajoutées selon les besoins.
    }
}
