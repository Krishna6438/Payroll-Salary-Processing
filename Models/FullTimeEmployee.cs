// FullTimeEmployee IS-A Employee (Inheritance)
using System.Threading.Channels;

public class FullTimeEmployee : Employee
{
    //private fields
    private decimal _monthlySalary;
    private decimal _bonus;

    // Read Only accessor
    public decimal MonthlySalary => _monthlySalary;
    public decimal Bonus => _bonus;

    // Validation with Constructor (Calling Parent class constructor also)

    public FullTimeEmployee(int id, string name, string department, string designation, DateTime joiningDate, bool isActive, decimal monthlySalary, decimal bonus) : base(id, name, department, designation, joiningDate, isActive)

    {
        if (monthlySalary <= 0)
        {
            throw new Exception("Monthly salary must be greater than zero.");
        }
        if(bonus < 0)
        {
            throw new Exception("Bonus can not be negative");
        }

        _monthlySalary = monthlySalary;
        _bonus = bonus;
    }

    // Overriding GrossSalary Method

    public override decimal CalculateGrossSalary()
    {
        return _monthlySalary + _bonus;
    }


}