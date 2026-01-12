public class Deduction
{
    // Stores tax percentage by designation
    private Dictionary<string, decimal> _taxRates = new Dictionary<string, decimal>(){
        { "Manager", 20 },
        { "Developer", 15 },
        { "Tester", 12 },
        { "Contractor", 10 },
        { "Intern", 5 }
    };

    // Calculate deduction based on designation and gross salary
    public decimal DeductionCalculation(Employee e, decimal grossSalary)
    {
        if (!_taxRates.ContainsKey(e.Designation))
        {
            return grossSalary * 0.1m; // Default 10% tax
        }
        // Retrieve the tax percentage based on the employee's designation
        // For example: Manager → 20%, Developer → 15%, etc.

        decimal taxPercent = _taxRates[e.Designation];

        // Convert percentage into decimal form and calculate the deduction amount
        // Example: If grossSalary = 50,000 and taxPercent = 20,
        // then deduction = 50,000 × (20 / 100) = 10,000
        return grossSalary * (taxPercent / 100);
    }

}