public class PayRollReport
{
    public void PrintReport()
    {
        Console.WriteLine("\n======= PAYROLL SUMMARY =======");

        var slips = DataBank.PaySlips;

        if (slips.Count == 0)
        {
            Console.WriteLine("No payroll data available.");
            return;
        }

        // Per-employee breakdown
        Console.WriteLine("\nID   Name       Type               Gross     Deduction   Net");
        Console.WriteLine("---------------------------------------------------------------");

        foreach (var s in slips)
        {
            Console.WriteLine(
                $"{s.EmployeeId,-4} {s.EmployeeName,-10} {s.EmployeeType,-18} {s.GrossSalary,8} {s.Deduction,10} {s.NetSalary,8}"
            );
        }

        // Totals
        decimal total = slips.Sum(s => s.NetSalary);
        var highestPaid = slips.OrderByDescending(s => s.NetSalary).First();
        var counts = slips.GroupBy(s => s.EmployeeType);

        Console.WriteLine("\n---------------------------------------------------------------");
        Console.WriteLine($"Total Employees Processed: {slips.Count}");
        Console.WriteLine($"Total Payout: {total}");

        Console.WriteLine("\nEmployees by Type:");
        foreach (var g in counts)
        {
            Console.WriteLine($"{g.Key} : {g.Count()}");
        }

        Console.WriteLine($"\nHighest Paid Employee: {highestPaid.EmployeeName} ({highestPaid.EmployeeType}) - {highestPaid.NetSalary}");
        Console.WriteLine("==============================================\n");
    }


}