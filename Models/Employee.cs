/*
    Auto-properties with { get; } give immutability, but private fields give full encapsulation and business-rule protection, which is required in payroll systems.”
*/

using System.Data.Common;

public abstract class Employee
{
    //  Private fields (Encapsulation)
    private int _id;
    private string _name;
    private string _department;
    private string _designation;
    private DateTime _joiningDate;
    private bool _isActive;


    //  Read-only public accessors

    public int Id => _id;
    public string Name => _name;
    public string Department => _department;
    public string Designation => _designation;
    public DateTime JoiningDate => _joiningDate;
    public bool IsActive => _isActive;

    // Validation Through Constructor
    // Only child classes can create an Employee.

    protected Employee(int id, string name, string department, string designation, DateTime joiningDate, bool isActive)
    {
        if (id <= 0)
            throw new Exception("Employee Id must be positive.");

        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Employee name cannot be empty.");

        if (string.IsNullOrWhiteSpace(department))
            throw new Exception("Department cannot be empty.");

        if (string.IsNullOrWhiteSpace(designation))
            throw new Exception("Designation cannot be empty.");

        if (joiningDate > DateTime.Now)
            throw new Exception("Joining date cannot be in the future.");

        _id = id;
        _name = name;
        _department = department;
        _designation = designation;
        _joiningDate = joiningDate;
        _isActive = isActive;
    }

    //  Polymorphism – salary calculation
    public abstract decimal CalculateGrossSalary();

    // Returns the actual runtime type of the employee object.
    // Even when an object is referenced using the base class (Employee),
    // GetType().Name gives the real derived class name such as FullTimeEmployee or ContractEmployee.
    // This supports polymorphism and avoids using if/else or type checking.

    public virtual string GetEmployeeType()
    {
        return GetType().Name;
    }

    // Overrides the default ToString() method of System.Object
    // This provides a meaningful textual representation of an Employee object
    // instead of showing only the class name.
    // It helps in logging, debugging, and displaying employee details in reports.



    public override string ToString()
    {
        // GetType().Name dynamically prints the actual runtime type
        // (FullTimeEmployee or ContractEmployee), enabling polymorphic display.
        // _designation adds role-based information for HR and payroll clarity.

        return $"{_id} - {_name} ({GetType().Name}, {_designation})";
    }
}