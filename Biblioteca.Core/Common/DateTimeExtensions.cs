using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Common;

public static class DateTimeExtensions
{
    public static DateTime GetFirstDay(this DateTime date, int? year = null, int? month = null)
        => new(year ?? date.Year, month ?? date.Month, day: 1);

    public static DateTime GetLastDay(this DateTime date, int? year = null, int? month = null)
        => new DateTime(year ?? date.Year, month ?? date.Month, day: 1).AddMonths(1).AddDays(-1);
}
