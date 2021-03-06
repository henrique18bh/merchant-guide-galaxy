﻿using MerchantGuideGalaxy.Constants;
using MerchantGuideGalaxy.Model;
using MerchantGuideGalaxy.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MerchantGuideGalaxy.Service
{
    public class InterpreterProcessorService : IInterpreterProcessorService
    {
        private readonly ICompilerService _compilerService;
        public IList<Keyword> ListKeywords { get; private set; }
        private string[] _keywords;
        private int _currentPosition;

        public InterpreterProcessorService(ICompilerService compilerService)
        {
            ListKeywords = new List<Keyword>();
            _compilerService = compilerService;
        }
        public string Execute(string text)
        {
            try
            {
                LoadText(text);
                return _compilerService.ExecuteQuery(ListKeywords);
            }
            catch (System.Exception)
            {
                return "I have no idea what you are talking about";
            }
        }

        public void LoadText(string text)
        {
            _currentPosition = -1;
            _keywords = text.Split(' ');
            ListKeywords = _keywords.Select(GetKeyword).ToList();
        }

        private Keyword GetKeyword(string value)
        {
            _currentPosition++;
            switch (value)
            {
                case Operators.Is:
                    return new Keyword(value, TypeKeyword.Operator);
                case IntergalacticUnits.Credits:
                    return new Keyword(value, TypeKeyword.IntergalacticUnit);
                case Questions.QueryQuestion:
                    return new Keyword(value, TypeKeyword.QueryQuestion);
                case RomanNumerals.I:
                case RomanNumerals.V:
                case RomanNumerals.X:
                case RomanNumerals.L:
                case RomanNumerals.C:
                case RomanNumerals.D:
                case RomanNumerals.M:
                    return new Keyword(value, TypeKeyword.RomanNumeral);
                case Verification.How:
                case Verification.Many:
                case Verification.Much:
                    return new Keyword(value, TypeKeyword.Verification);
            }
            if (int.TryParse(value, out int testValue))
            {
                return new ValueKeyword(value, TypeKeyword.Value);
            }
            if (value == _keywords.First())
            {
                return new Keyword(value, TypeKeyword.Constant);
            }
            return ValidateConstantClassifier(value);
        }

        private Keyword ValidateConstantClassifier(string value)
        {
            string previous = _currentPosition == 0
                           ? null
                           : _keywords[_currentPosition - 1];

            string next = _currentPosition == _keywords.Length - 1
                       ? null
                       : _keywords[_currentPosition + 1];

            if (!(previous == Verification.Many || previous == Verification.Much)
                && next == Operators.Is)
            {
                return new Keyword(value, TypeKeyword.Classifier);
            }

            if (next == Questions.QueryQuestion && _keywords.Contains(Verification.Many))
            {
                return new Keyword(value, TypeKeyword.Classifier);
            }

            return new Keyword(value, TypeKeyword.Constant);
        }
    }
}
