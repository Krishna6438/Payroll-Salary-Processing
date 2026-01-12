public class ContractEmployee : Employee
{
    // Private fields
    decimal _dailyRate;
    decimal _workingDays;

    // Read only accessors

    public decimal DailyRate => _dailyRate;
    public decimal WorkingDays => _workingDays;

    // Validation with Constructor (Calling Parent class constructor also )

    public ContractEmployee(int id, string name, string department, string designation, DateTime joiningDate, bool isActive, decimal dailyRate, decimal workingDays) : base(id, name, department, designation, joiningDate, isActive)
    {
        if (dailyRate <= 0)
        {
            throw new Exception("Daily Rate must be greater than zero.");
        }
        if (workingDays < 0)
        {
            throw new Exception("Working days can not be less than zero.");
        }

        _dailyRate = dailyRate;
        _workingDays = workingDays;
    }

    // Overriding GrossSalary

    public override decimal CalculateGrossSalary()
    {
        return _dailyRate * _workingDays;
    }


}