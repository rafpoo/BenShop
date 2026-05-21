using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace benshop.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone ?? "", @"^0\d{8,13}$");
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPositiveNumber(decimal value)
        {
            return value > 0;
        }

        public static bool IsPositiveNumber(int value)
        {
            return value > 0;
        }

        public static bool IsValidDiscountPercent(decimal percent)
        {
            return percent > 0 && percent <= 100;
        }
    }
}
