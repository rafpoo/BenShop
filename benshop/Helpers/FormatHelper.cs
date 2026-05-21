using System;

namespace benshop.Helpers
{
    public static class FormatHelper
    {
        public static string ToRupiah(decimal amount)
        {
            return string.Format("Rp {0:N0}", amount);
        }

        public static string ToRupiah(int amount)
        {
            return ToRupiah(Convert.ToDecimal(amount));
        }
    }
}
