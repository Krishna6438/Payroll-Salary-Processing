/*
Employees are created
Stored in DataBank
Payroll is processed
Delegates are wired
Reports are printed

*/
using System.Data;

class Program
{
    public static void Main(String[] args)
    {
        try
        {
            // Create employees (Hardcoded as per assignment)
            DataBank.Employees.Add(1, new FullTimeEmployee(1, "Krishna", "IT", "Developer", DateTime.Now.AddYears(-2), true, 60000, 5000));
            DataBank.Employees.Add(2, new FullTimeEmployee(2, "Aman", "HR", "Manager", DateTime.Now.AddYears(-4), true, 80000, 10000));
            DataBank.Employees.Add(3, new ContractEmployee(3, "Ravi", "IT", "Contractor", DateTime.Now.AddMonths(-10), true, 2000, 22));
            DataBank.Employees.Add(4, new ContractEmployee(4, "Neha", "Design", "Contractor", DateTime.Now.AddMonths(-6), true, 1800, 20));
            DataBank.Employees.Add(5, new FullTimeEmployee(5, "Pooja", "QA", "Tester", DateTime.Now.AddYears(-1), true, 50000, 3000));
            DataBank.Employees.Add(6, new FullTimeEmployee(6, "Ankit", "IT", "Developer", DateTime.Now.AddYears(-3), true, 65000, 7000));

            // Create services
            PayrollProcessor processor = new PayrollProcessor();
            HRNotificationService hr = new HRNotificationService();
            FinanceNotificationService finance = new FinanceNotificationService();

            // Process payroll
            processor.SalaryProcessed += hr.Notify;
            processor.SalaryProcessed += finance.Notify;

            processor.ProcessPayroll();

            // Generate report
            PayRollReport report = new PayRollReport();
            report.PrintReport();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Application error ... {e.Message}");
        }
    }

}