using System;
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
        const int MaxNumberOfGuesses = 7;

        //Properties
        public bool CanMakeGuess
        {
            get
            {
                if (_guessedNumbers.Count > MaxNumberOfGuesses)
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
            _number = 100; //Fixa random
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess != _number)
            {
                Count++;
                if (guess < _number)
                {
                    return Outcome.Low;
                }
                else if (guess > _number)
                {
                    return Outcome.High;
                }
                else if (guess == _number)
                {
                    return Outcome.Right;
                }
            }

            return Outcome.Indefinite;
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