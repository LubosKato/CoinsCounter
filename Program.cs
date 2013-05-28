using System;
using System.Collections.Generic;

namespace CoinsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amount = 79;
            string result = amount.ToString() + "CZK = {";
            var coins = CalculateCoins(amount);
            foreach (var coin in coins)
            {
                result += coin.Key + "=>" + coin.Value + ", ";
            }
            Console.WriteLine(result.TrimEnd(new char[] { ',', ' ' }) + "}");
            Console.ReadLine();
        }

        public static Dictionary<string, string> CalculateCoins(decimal amount)
        {
            int total = (int)amount;
            int[,] Coins = new int[6, 2] { { 50, 0 }, { 20, 0 }, { 10, 0 }, { 5, 0 }, { 2, 0 }, { 1, 0 } };
            var result = new Dictionary<string, string>();

            for (int i = 0; i < 6; i++)
            {
                int numCoins = 0;
                while (total >= Coins[i, 0])
                {
                    total -= Coins[i, 0];
                    numCoins++;
                }
                Coins[i, 1] = numCoins;
                if (Coins[i, 1] != 0)
                    result.Add(Coins[i, 0].ToString(), Coins[i, 1].ToString());
            }
            return result;
        }
    }
}
