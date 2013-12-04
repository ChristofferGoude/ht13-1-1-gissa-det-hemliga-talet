using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberGuessingGame.Controllers
{
    public class NumberGuessingGameController : Controller
    {

        private SecretNumber SecretNumber
        {
            get
            {
                var secretNumber = Session["secretNumber"] as SecretNumber;
                if (secretNumber == null)
                {
                    secretNumber = new SecretNumber();
                    Session["secretNumber"] = secretNumber;
                    secretNumber.Initialize();
                }
                return secretNumber;
            }
            set
            {
                Session["secretNumber"] = value;
            }
        }

        private SecretNumberViewModel SecretNumberViewModel
        {
            get
            {
                var secretNumberViewModel = new SecretNumberViewModel { SecretNumber = this.SecretNumber };

                return secretNumberViewModel;
            }
        }

        // GET
        public ActionResult Index()
        {
            return View("Index", SecretNumberViewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SecretNumberViewModel model)
        {
            if (Session.IsNewSession)
            {
                return View("SessionOver");
            }
            if (!SecretNumberViewModel.SecretNumber.HasGameStarted)
            {
                SecretNumberViewModel.SecretNumber.Initialize();
            }
            try
            {
                if (SecretNumberViewModel.SecretNumber.CanMakeGuess && ModelState.IsValid)
                {
                    SecretNumberViewModel.SecretNumber.MakeGuess(model.Guess);
                }
            }
            catch
            {
                ModelState.AddModelError("Guess", "Gissningen måste vara ett heltal");
            }
            return View("Index", SecretNumberViewModel);
        }

        [HttpPost, ActionName("NewGame")]
        public ActionResult NewGame()
        {
            SecretNumberViewModel.SecretNumber.Initialize();
            return RedirectToAction("Index");
        }
    }
}
