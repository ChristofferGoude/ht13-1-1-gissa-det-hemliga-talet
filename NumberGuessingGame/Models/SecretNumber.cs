﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
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
                if (Count >= MaxNumberOfGuesses)
                {
                    return false;
                }
                else
                {
                    return false;
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
            _guessedNumbers = null;
            _number = 32; //Fixa random
        }

        public Outcome MakeGuess(int guess)
        {
            GuessedNumber newGuess = new GuessedNumber();
            Outcome guessOutcome = Outcome.Indefinite;
            Count++;
            if (Count <= MaxNumberOfGuesses)
            {
                if (guess != _number)
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

                    if (guess < _number)
                    {
                        guessOutcome = Outcome.Low;
                    }
                    else if (guess > _number)
                    {
                        guessOutcome = Outcome.High;
                    }
                }
                else if (guess == _number)
                {
                    guessOutcome = Outcome.Right;
                }
            }

            else
            {
                guessOutcome = Outcome.NoMoreGuesses;
            }

            newGuess.Number = guess;
            newGuess.Outcome = guessOutcome;
            _guessedNumbers.Add(newGuess);
            _lastGuessedNumber = newGuess;

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