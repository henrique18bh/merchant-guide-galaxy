﻿using MerchantGuideGalaxy.Constants;
using MerchantGuideGalaxy.Exception;
using MerchantGuideGalaxy.Extensions;
using MerchantGuideGalaxy.Model;
using MerchantGuideGalaxy.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGuideGalaxy.Service
{
    public class CompilerService : ICompilerService
    {
        private IList<ValueDefenition> _constantsDefinitios;
        private IList<ValueDefenition> _classifiersDefinitios;
        private readonly IConfiguration _configuration;

        public CompilerService(IConfiguration configuration)
        {
            _configuration = configuration;
            _constantsDefinitios = new List<ValueDefenition>();
            _classifiersDefinitios = new List<ValueDefenition>();
        }

        public string ExecuteQuery(IList<Keyword> listKeywords)
        {
            switch (DefineTypeExecution(listKeywords))
            {
                case TypeQuery.Declaration:
                    return ExecuteDeclarationQuery(listKeywords);
                case TypeQuery.IntergalacticDefinition:
                    return ExecuteIntergalacticDefinitionQuery(listKeywords);
                case TypeQuery.Result:
                    return ExecuteResultQuery(listKeywords);
                default:
                    throw new TypeExecutionException();
            }
        }

        private TypeQuery DefineTypeExecution(IList<Keyword> listKeywords)
        {
            if (listKeywords.Count == 3
                && listKeywords.Any(s => s.Type == TypeKeyword.Constant)
                && listKeywords.Any(s => s.Type == TypeKeyword.Operator)
                && listKeywords.Any(s => s.Type == TypeKeyword.RomanNumeral))
            {
                return TypeQuery.Declaration;
            }

            if (listKeywords.Any(s => s.Type == TypeKeyword.Constant)
                && listKeywords.Any(s => s.Type == TypeKeyword.Classifier)
                && listKeywords.Any(s => s.Type == TypeKeyword.Value)
                && listKeywords.Any(s => s.Type == TypeKeyword.IntergalacticUnit))
            {
                return TypeQuery.IntergalacticDefinition;
            }

            if (listKeywords.Any(s => s.Type == TypeKeyword.Verification)
                 && listKeywords.Any(s => s.Type == TypeKeyword.Operator)
                 && listKeywords.Any(s => s.Type == TypeKeyword.Constant)
                 && listKeywords.Any(s => s.Type == TypeKeyword.QueryQuestion))
            {
                return TypeQuery.Result;
            }

            throw new TypeExecutionException();
        }

        private string ExecuteDeclarationQuery(IList<Keyword> listKeywords)
        {
            var exists = (from item in _constantsDefinitios
                          where item.Type == TypeKeyword.Constant
                              && item.TypeName.Equals(listKeywords.FirstOrDefault().Name)
                          select item).Any();
            if (exists)
            {
                return "Item already been registered!";
            }
            _constantsDefinitios.Add(new ValueDefenition(listKeywords.FirstOrDefault().Name, 
                                                         listKeywords.LastOrDefault().Name, 
                                                         TypeKeyword.Constant));
            return "Declaration Registred.";

        }

        private string ExecuteIntergalacticDefinitionQuery(IList<Keyword> listKeywords)
        {
            var constants = listKeywords.Where(x => x.Type == TypeKeyword.Constant).ToList();
            var classifier = listKeywords.FirstOrDefault(x => x.Type == TypeKeyword.Classifier);
            var value = listKeywords.FirstOrDefault(x => x.Type == TypeKeyword.Value) as ValueKeyword;

            double convertedValue = value.Number / CalculateValue(constants);

            var exists = (from item in _classifiersDefinitios
                          where item.Type == TypeKeyword.Classifier
                              && item.TypeName.Equals(classifier.Name)
                          select item).Any();
            if (exists)
            {
                return "Item already been registered!";
            }
            _classifiersDefinitios.Add(new ValueDefenition(classifier.Name,
                                                         convertedValue,
                                                         TypeKeyword.Classifier));

            return "Declaration Registred.";
        }

        private string ExecuteResultQuery(IList<Keyword> listKeywords)
        {
            var verifications = listKeywords.Where(x => x.Type == TypeKeyword.Verification).ToList();
            var constants = listKeywords.Where(x => x.Type == TypeKeyword.Constant).ToList();
            var calculateValue = CalculateValue(constants);
            var constantsName = string.Join(" ",constants.Select(c => c.Name.ToString()));
            var classifier = listKeywords.FirstOrDefault(x => x.Type == TypeKeyword.Classifier);
            var intergalacticUnit = listKeywords.FirstOrDefault(x => x.Type == TypeKeyword.IntergalacticUnit);

            if (verifications.Any(x => x.Name.Equals(Verification.Much)))
            {
                return string.Format("{0} is {1}", constantsName, calculateValue);
            }

            calculateValue *= _classifiersDefinitios.FirstOrDefault(x => x.TypeName.Equals(classifier.Name)).Value ?? 1;

            return string.Format("{0} {1} is {2} {3}", constantsName, classifier.Name, calculateValue, intergalacticUnit.Name);
        }

        private double CalculateValue(IList<Keyword> constants)
        {
            var roman = new StringBuilder();
            constants.Select(x => _constantsDefinitios.FirstOrDefault(y => y.TypeName.Equals(x.Name)).RomanValue)
                .ToList()
                .ForEach(item => roman.Append(item));
            return roman.ToString().ConvertRomanNumeralsToInt(_configuration["RomanConfig:RomanRegex"]);
        }
    }
}
