/*
Reads employees from DataBank
Calculates salary using polymorphism
Applies deductions
Creates PaySlips
Fires delegate notifications
*/

public class PayrollProcessor
{
    private Deduction d = new Deduction();
    // Multicast delegate
    public SalaryProcessedHandler SalaryProcessed;

    // Process payroll for all employees
    public void ProcessPayroll()
    {
        Console.WriteLine("\n--- Payroll Processing Started ---\n");

        foreach (var emp in DataBank.Employees.Values)
        {
            try
            {
                // Step 1: Polymorphic gross salary calculation
                decimal gross = emp.CalculateGrossSalary();
                
                // Step 2: Deduction based on designation
                decimal ded = d.DeductionCalculation(emp, gross);

                // Step 3: Create PaySlip
                PaySlip slip = new PaySlip(emp.Id,
                emp.Name,
                emp.GetEmployeeType(),
                gross,
                ded);
            
                // Step 4: Store payslip

                DataBank.PaySlips.Add(slip);

                // Step 5: Notify HR & Finance via delegate
                SalaryProcessed?.Invoke(emp, slip);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing employee {emp.Name}: {ex.Message}");
            }
        }
        Console.WriteLine("\n--- Payroll Processing Completed ---\n");

    }

}