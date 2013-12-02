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

        // GET: /NumberGuessingGame/Index
        public ActionResult Index()
        {
            SecretNumber.Initialize();
            return View();
        }

        // POST: /NumberGuessingGame/NewGame
        [HttpPost, ActionName("PlayGame")]
        public ActionResult NewGame()
        {
            return RedirectToAction("PlayGame");
        }

        // GET: /NumberGuessingGame/PlayGame
        public ActionResult PlayGame()
        {
            return View(SecretNumberViewModel);
        }

        // POST: /NumberGuessingGame/
        [HttpPost, ActionName("NewGuess")]
        public ActionResult NewGuess(SecretNumberViewModel ViewModel)
        {
            SecretNumber.MakeGuess(ViewModel.Guess);

            return RedirectToAction("PlayGame");
        }
    }
}
