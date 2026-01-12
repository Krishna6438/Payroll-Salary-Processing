// Static class for data storage

using System.Collections.Generic;

public static class DataBank
{
    // Stores all employees in memory (Key = Employee Id)
    public static Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

    // Stores all generated salary slips
    public static List<PaySlip> PaySlips = new List<PaySlip>();

    // Stores all notification messages (HR + Finance)
    public static Queue<string> Notifications = new Queue<string>();
}