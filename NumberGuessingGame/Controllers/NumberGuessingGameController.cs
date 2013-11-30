using NumberGuessingGame.Models;
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

        // GET: /NumberGuessingGame/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: /NumberGuessingGame/NewGame
        [HttpPost, ActionName("PlayGame")]
        public ActionResult NewGame()
        {
            SecretNumber.Initialize();

            return RedirectToAction("PlayGame");
        }

        // GET: /NumberGuessingGame/PlayGame
        public ActionResult PlayGame()
        {
            return View(model);
        }

        // POST: /NumberGuessingGame/
        [HttpPost]
        public ActionResult PlayGame(int guess)
        {
            model.MakeGuess(guess);

            return RedirectToAction("PlayGame", model);
        }
    }
}
