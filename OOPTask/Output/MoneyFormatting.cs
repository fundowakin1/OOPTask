using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask.Output
{
    internal class MoneyFormatting
    {
        public static decimal[] SplitDecimalToString(decimal money)
        {
            return money.ToString("0.00", CultureInfo.InvariantCulture).Split('.').Select(decimal.Parse).ToArray();
        }
    }
}
