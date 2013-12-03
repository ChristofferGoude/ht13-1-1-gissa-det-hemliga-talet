using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberGuessingGame.ViewModel
{
    public class SecretNumberViewModel
    {
        public SecretNumber SecretNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage="Du måste ange en gissning!")]
        [Range(1, 100, ErrorMessage="Din gissning måste ligga mellan 1 och 100!")]
        public int Guess
        {
            get;
            set;
        }
    }
}