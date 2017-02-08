using System.ComponentModel.DataAnnotations;

namespace CSharp.Helpers.Extensions
{
    public class BooleanRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }
    }
}