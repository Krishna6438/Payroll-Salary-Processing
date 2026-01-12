public class FinanceNotificationService
{
    // Method that matches delegate signature
    public void Notify(Employee employee, PaySlip slip)
    {
        string message = $"[Finance] Payment approved for Employee ID {employee.Id} - Amount: {slip.NetSalary}";
        Console.WriteLine(message);

        // Store message in DataBank
        DataBank.Notifications.Enqueue(message);
    }
}