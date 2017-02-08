using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp.Helpers.Extensions
{
    /// <summary>
    /// Compare two times,the second time (To) must be greater than the first time
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class IsTimeGreaterThanAttribute: ValidationAttribute
    {
        private readonly string _ComparedPropertyName;
        private readonly bool _AllowEqualDates;

        public IsTimeGreaterThanAttribute(string comparedPropertyName, bool allowEqualTimes)
        {
            _ComparedPropertyName = comparedPropertyName;
            _AllowEqualDates = allowEqualTimes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comparedPropertyInfo = validationContext.ObjectType.GetProperty(this._ComparedPropertyName);
            if (comparedPropertyInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this._ComparedPropertyName));
            }

            var comparedPropertyValue = comparedPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || comparedPropertyValue == null)
            {
                return ValidationResult.Success;
            }

            TimeSpan valueTimeSpan = TimeSpan.MinValue;
            TimeSpan.TryParse(value.ToString(), out valueTimeSpan);
            TimeSpan comparedValueTimeSpan = TimeSpan.MinValue;
            TimeSpan.TryParse(comparedPropertyValue.ToString(), out comparedValueTimeSpan);

            // Compare values
            if (valueTimeSpan >= comparedValueTimeSpan)
            {
                if (this._AllowEqualDates)
                {
                    return ValidationResult.Success;
                }
                if (valueTimeSpan > comparedValueTimeSpan)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
