using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BidOneAssessment.Core
{
    public class NotScriptPropertyValidator : PropertyValidator
    {
        public NotScriptPropertyValidator() : base("Contains invalid characters '<' or '>'.")
        {
        }


        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            var value = (string)context.PropertyValue;

            if (value.Contains("<") || value.Contains(">"))
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Validates if the string property is a valid numeric string of specified size
    /// </summary>
    public class NumericStringPropertyValidator : PropertyValidator
    {
        private readonly int _minSize;
        private readonly int _maxSize;
        public NumericStringPropertyValidator(int minSize, int maxSize) : base("Should only contain numeric characters.")
        {
            _minSize = minSize;
            _maxSize = maxSize;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return false;

            var value = (string)context.PropertyValue;

            var numericRegex = new Regex(@"^[0-9]+$");

            return value.Length >= _minSize && value.Length <= _maxSize && numericRegex.IsMatch(value);
        }
    }

    public static partial class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> NotExecutableScript<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new NotScriptPropertyValidator());
        }

        public static IRuleBuilderOptions<T, string> NumericStringOfSize<T>(this IRuleBuilder<T, string> ruleBuilder, int expectedSize)
        {
            return ruleBuilder.SetValidator(new NumericStringPropertyValidator(expectedSize, expectedSize));
        }

        public static IRuleBuilderOptions<T, string> NumericStringOfSize<T>(this IRuleBuilder<T, string> ruleBuilder, int minSize, int maxSize)
        {
            return ruleBuilder.SetValidator(new NumericStringPropertyValidator(minSize, maxSize));
        }
    }
}
