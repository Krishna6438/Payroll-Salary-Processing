// Delegate that represents a salary processed notification
// It will be called after each employee salary is calculated
public delegate void SalaryProcessedHandler(Employee employee, PaySlip slip);