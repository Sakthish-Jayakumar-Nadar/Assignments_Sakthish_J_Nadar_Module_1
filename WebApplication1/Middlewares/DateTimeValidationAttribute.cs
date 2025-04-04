using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Middlewares
{
    public class DateTimeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTimeValue)
            {
                return dateTimeValue >= DateTime.Now;
            }
            return false;
        }
    }
}
