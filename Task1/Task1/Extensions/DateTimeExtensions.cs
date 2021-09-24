using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Extensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        ///     A DateTime extension method that return a DateTime of the last day of the month with the time set to
        ///     "23:59:59:999".
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the last day of the month with the time set to "23:59:59:999".</returns>
        public static DateTime EndOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1).AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        ///     A DateTime extension method that return a DateTime of the first day of the month with the time set to
        ///     "00:00:00:000".
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the first day of the month with the time set to "00:00:00:000".</returns>
        public static DateTime StartOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1);
        }
        /// <summary>
        /// A DateTime extension method that return a DateTime with subtracted months
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="months">The months to subtract</param>
        /// <returns>A DateTime with subtracted months.</returns>
        public static DateTime SubtractMonths(this DateTime @this, int months)
        {
            return @this.AddMonths(-1 * months);
        }
    }
}
