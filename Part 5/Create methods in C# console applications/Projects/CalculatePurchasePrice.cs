using System;

class Program
{
    static void Main()
    {
        const double MinimumSpend = 30.00;
        const double DiscountAmount = 5.00;

        double[] itemPrices = { 15.97, 3.50, 12.25, 22.99, 10.98 };
        double[] itemDiscounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

        double total = CalculateTotalWithDiscounts(itemPrices, itemDiscounts);

        if (total >= MinimumSpend)
        {
            total -= DiscountAmount;
        }

        Console.WriteLine($"Total: ${total.ToString("F2")}");
    }

    static double CalculateTotalWithDiscounts(double[] prices, double[] discounts)
    {
        double total = 0.0;

        for (int i = 0; i < prices.Length; i++)
        {
            double discountedPrice = prices[i] * (1 - discounts[i]);
            total += discountedPrice;
        }

        return total;
    }
}