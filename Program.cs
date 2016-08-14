using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>(new object[] { 2482000767, 343765, "" });
            string tempCurrency = String.Empty;
            tempCurrency = GetCurrency(list);
            list = ConvertData(tempCurrency, list);
            Console.WriteLine(tempCurrency);
            foreach (object item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static List<object> ConvertData(string format, List<object> value)
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
        private static List<object> calculateNA(List<object> value)
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
                tempList.Add((Convert.ToDouble(item) / 1000000));

            }
            return tempList;
        }
        private static List<object> calculateB(List<object> value)
        {
            List<object> tempList = new List<object>();
            foreach (object item in value)
            {
                tempList.Add((Convert.ToDouble(item) / 1000000000));
            }
            return tempList;
        }
        static string GetCurrency(List<object> value)
        {
            string tempCurrency = String.Empty;
            value.RemoveAll(x => x.ToString() == "");
            List<double> doubleList = value.ConvertAll(x => Convert.ToDouble(x));
            var max = doubleList.Max();
            tempCurrency = getCurrencyCode(max);
            return tempCurrency;
        }
        static string getCurrencyCode(double value)
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
