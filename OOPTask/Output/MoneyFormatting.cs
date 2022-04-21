using System.Globalization;
using System.Linq;

namespace OOPTask.Output
{
    public class MoneyFormatting
    {
        public static int[] SplitDecimalToString(decimal money)
        {
            return money.ToString("0.00", CultureInfo.InvariantCulture).Split('.').Select(int.Parse).ToArray();
        }
    }
}
