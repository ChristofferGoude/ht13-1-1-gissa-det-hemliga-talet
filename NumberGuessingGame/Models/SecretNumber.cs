using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers = new List<GuessedNumber>();
        private GuessedNumber _lastGuessedNumber;
        private int? _number = 0;
        private int _numberOfGuesses;
        public const int MaxNumberOfGuesses = 7;

        //Properties 
        public int? Number
        {
            get
            {
                if (!CanMakeGuess)
                {
                    return _number;
                }
                return null;
            }
        }

        public bool HasGameStarted
        {
            get
            {
                if (_number == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || LastGuessedNumber.Number == _number)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public IReadOnlyList<GuessedNumber> GuessedNumbers
        {
            get
            {
                return _guessedNumbers;
            }
        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                return _lastGuessedNumber;
            }
        }

        public int Count
        {
            get
            {
                return _numberOfGuesses;
            }
            set
            {
                _numberOfGuesses = value;
            }
        }

        //Methods
        public void Initialize()
        {
            Count = 0;
            _guessedNumbers.Clear();
            var rnd = new Random();
            _number = rnd.Next(1, 101);
        }

        public Outcome MakeGuess(int guess)
        {
            GuessedNumber newGuess = new GuessedNumber();
            Outcome guessOutcome = Outcome.odefinierad;
            Count++;

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count <= MaxNumberOfGuesses)
            {
                if (guess != _number)
                {
                    if (guess < _number)
                    {
                        guessOutcome = Outcome.låg;
                    }
                    else if (guess > _number)
                    {
                        guessOutcome = Outcome.hög;
                    }

                    foreach (GuessedNumber guessedNumber in _guessedNumbers)
                    {
                        if (guess == guessedNumber.Number)
                        {
                            Count--;
                            guessOutcome = Outcome.gammal;
                            break;
                        }
                    }
                }
                else if (guess == _number)
                {
                    guessOutcome = Outcome.rätt;
                }
            }
            else
            {
                guessOutcome = Outcome.slut;
            }

            newGuess.Number = guess;
            newGuess.Outcome = guessOutcome;
            _lastGuessedNumber = newGuess;
            _guessedNumbers.Add(newGuess);

            return guessOutcome;
        }
    }

    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }

    public enum Outcome
    {
        odefinierad,
        låg,
        hög,
        rätt,
        slut,
        gammal
    }
}