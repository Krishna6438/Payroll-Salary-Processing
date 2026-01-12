public class PaySlip
{
    // Private Fields
    private int _employeeId;
    private string _employeeName;
    private string _employeeType;
    private decimal _grossSalary;
    private decimal _deduction;
    private decimal _netSalary;
    private DateTime _payDate;

    // Read Only Accessor
    public int EmployeeId => _employeeId;
    public string EmployeeName => _employeeName;
    public string EmployeeType => _employeeType;
    public decimal GrossSalary => _grossSalary;
    public decimal Deduction => _deduction;
    public decimal NetSalary => _netSalary;
    public DateTime PayDate => _payDate;

    // Validation with Constructor

    public PaySlip(int id, string name, string type, decimal gross, decimal deduction )
    {
        if(gross <=0)
        {
            throw new Exception("Gross salary must be greater than zero.");
        }
        if(deduction < 0)
        {
            throw new Exception("Deduction cannot be negative");
        }
        _employeeId = id;
        _employeeName = name;
        _employeeType = type;
        _grossSalary = gross;
        _deduction = deduction;
        _netSalary = gross - deduction;
        _payDate = DateTime.Now;
    }

    // Meaningful print
    public override string ToString()
    {
        return $"{_employeeId} | {_employeeName} | {_employeeType} | Gross: {_grossSalary} | Deduction: {_deduction} | Net: {_netSalary}";
    }
}