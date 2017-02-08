using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CSharp.Helpers.ValidationAttributes
{
    /// <summary>
    /// Compare two times,the second time (To) must be greater than the first time
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class IsGreaterThanAttribute: ValidationAttribute
    {
        private readonly int _ComparedValue;
        private readonly bool _AllowEquality;

        public IsGreaterThanAttribute(int comparedValue, bool allowEquality, string errorMessage)
        {
            _ComparedValue = comparedValue;
            _AllowEquality = allowEquality;
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }

            var valueToInt = 0;
            if(!int.TryParse(value.ToString(), out valueToInt))
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} is not an integer.", validationContext.DisplayName));
            }

            // Compare values
            if (valueToInt >= _ComparedValue)
            {
                if (this._AllowEquality)
                {
                    return ValidationResult.Success;
                }
                if (valueToInt > _ComparedValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
