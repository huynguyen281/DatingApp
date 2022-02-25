using System;

namespace DatingApp.API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            if (dateOfBirth == null)
            {
                return 0;
            }
            var today = DateTime.Now;
            var age = today.Year - dateOfBirth.Year;
            return age;
        }
    }
}