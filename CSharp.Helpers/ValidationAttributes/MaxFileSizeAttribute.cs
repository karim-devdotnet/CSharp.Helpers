using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CSharp.Helpers.Extensions
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        /// <summary>
        /// in MB
        /// </summary>
        private readonly int _maxFileSize;

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxFileSize">in MB</param>
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }
            return ConvertBytesToMegabytes(file.ContentLength) <= _maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }

        private double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}