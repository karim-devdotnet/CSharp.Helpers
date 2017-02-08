using System.ComponentModel.DataAnnotations;

namespace CSharp.Helpers.ValidationAttributes
{
    public class BooleanRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }
    }
}