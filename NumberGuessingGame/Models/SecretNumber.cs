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
        private bool _canMakeGuess = true;
        private int? _number;
        private int _numberOfGuesses;
        public const int MaxNumberOfGuesses = 7;

        //Properties 
        public int? Number
        {
            get
            {
                return _number;
            }
        }

        public bool CanMakeGuess
        {
            get
            {
                return _canMakeGuess;
            }
            set
            {
                _canMakeGuess = value;
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
            Outcome guessOutcome = Outcome.Indefinite;
            Count++;

            if (Count <= MaxNumberOfGuesses)
            {
                if (guess != Number)
                {
                    foreach (GuessedNumber guessedNumber in _guessedNumbers)
                    {
                        if (guess == guessedNumber.Number)
                        {
                            Count--;
                            guessOutcome = Outcome.OldGuess;
                            break;
                        }
                    }

                    if (guess < Number)
                    {
                        guessOutcome = Outcome.Low;
                    }
                    else if (guess > Number)
                    {
                        guessOutcome = Outcome.High;
                    }
                }
                else if (guess == Number)
                {
                    guessOutcome = Outcome.Right;
                    CanMakeGuess = false;
                }
            }
            else
            {
                guessOutcome = Outcome.NoMoreGuesses;
                CanMakeGuess = false;
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
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }
}