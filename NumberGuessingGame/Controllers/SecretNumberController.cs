using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberGuessingGame.Controllers
{
    public class SecretNumberController : Controller
    {
        public ActionResult Index()
        {
            var model = new SecretNumber();
            return View(model);
        }

    }
}
