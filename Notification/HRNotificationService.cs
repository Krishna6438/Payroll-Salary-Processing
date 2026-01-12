public class HRNotificationService
{
    // Method that matches delegate signature
    public void Notify(Employee employee, PaySlip slip)
    {
        string message = $"[HR] Salary processed for {employee.Name} ({employee.GetEmployeeType()}) - Net Salary: {slip.NetSalary}";
        Console.WriteLine(message);

        // Store message in DataBank
        DataBank.Notifications.Enqueue(message);
    }
}