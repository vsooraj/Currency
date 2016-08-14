using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyFormat
{
    public static class Currency
    {
        public static List<object> ConvertData(string format, List<object> value)
        {
            List<object> tempList = new List<object>();
            switch (format)
            {
                case "K":
                    return calculateK(value);
                case "M":
                    return calculateM(value);
                case "B":
                    return calculateB(value);
                case "H":
                    return calculateNA(value);
                default:
                    break;
            }
            return tempList;
        }
        static List<object> calculateNA(List<object> value)
        {
            return value;
        }
        private static List<object> calculateK(List<object> value)
        {
            List<object> tempList = new List<object>();
            foreach (object item in value)
            {
                tempList.Add((Convert.ToDouble(item) / 1000));

            }
            return tempList;
        }
        private static List<object> calculateM(List<object> value)
        {
            List<object> tempList = new List<object>();
            foreach (object item in value)
            {
                tempList.Add(Math.Truncate(((Convert.ToDouble(item) / 1000000)) * 100) / 100);

            }
            return tempList;
        }
        private static List<object> calculateB(List<object> value)
        {
            List<object> tempList = new List<object>();
            foreach (object item in value)
            {
                tempList.Add(Math.Truncate(((Convert.ToDouble(item) / 1000000000)) * 100) / 100);
            }
            return tempList;
        }
        public static string GetCurrency(List<object> value)
        {
            string tempCurrency = String.Empty;
            value.RemoveAll(x => x.ToString() == "");
            List<double> doubleList = value.ConvertAll(x => Convert.ToDouble(x));
            var max = doubleList.Max();
            tempCurrency = GetCurrencyCode(max);
            return tempCurrency;
        }
        static string GetCurrencyCode(double value)
        {
            if (value == 0)
            {
                return "O";
            }
            else
            {
                // billions
                if (value >= 1000000000 && value <= 999999999999)
                {
                    return "B";
                }
                // millions
                else if (value >= 1000000 && value <= 999999999)
                {
                    return "M";
                }
                // thousands
                else if (value >= 1000 && value <= 999999)
                {
                    return "K";
                }
                // hundreds
                else if (value <= 999)
                {
                    return "H";
                }
                else
                {
                    return "O";
                }

            }
        }
    }
}
