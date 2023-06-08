using AbstractClass.Entities;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the number of tax payers: ");
        int N = int.Parse(Console.ReadLine());

        List<TaxPayer> list = new List<TaxPayer>();

        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine($"Tax payer #{i} data:");
            Console.Write("Individual or company (i/c): ");
            char Ch = char.Parse(Console.ReadLine());
            if (Ch == 'i')
            {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Anual income: ");
                double AnualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Health expenditures: ");
                double HealthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Individual(Name, AnualIncome, HealthExpenditures));
            }
            else
            {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Anual income: ");
                double AnualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Number of employees: ");
                int NumberOfEmployees = int.Parse(Console.ReadLine());
                list.Add(new Company(Name, AnualIncome, NumberOfEmployees));
            }
        }

        Console.WriteLine();

        double TotalTax = 0.0;

        Console.WriteLine("TAXE(S) PAID:");
        foreach (TaxPayer taxPayer in list)
        {
            Console.WriteLine(taxPayer.Name
                + ": $ "
                + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
            TotalTax += taxPayer.Tax();
        }

        Console.WriteLine();
        Console.WriteLine("TOTAL TAXES: $ " + TotalTax.ToString("F2", CultureInfo.InvariantCulture));
    }
}