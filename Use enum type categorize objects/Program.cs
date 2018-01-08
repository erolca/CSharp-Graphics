using System;

enum EmployeeTypeEnum
{
    Employee,
    Manager
}

class Employee
{
    public Employee(string name, float billingRate)
    {
        this.name = name;
        this.billingRate = billingRate;
        type = EmployeeTypeEnum.Employee;
    }

    public float CalculateCharge(float hours)
    {
        if (type == EmployeeTypeEnum.Manager)
        {
            Manager c = (Manager)this;
            return (c.CalculateCharge(hours));
        }
        else if (type == EmployeeTypeEnum.Employee)
            return (hours * billingRate);
        return (0F);
    }

    public string TypeName()
    {
        if (type == EmployeeTypeEnum.Manager)
        {
            Manager c = (Manager)this;
            return (c.TypeName());
        }
        else if (type == EmployeeTypeEnum.Employee)
            return ("Employee");
        return ("No Type Matched");
    }

    private string name;
    protected float billingRate;
    protected EmployeeTypeEnum type;
}

class Manager : Employee
{
    public Manager(string name, float billingRate) :
    base(name, billingRate)
    {
        type = EmployeeTypeEnum.Manager;
    }

    public new float CalculateCharge(float hours)
    {
        if (hours < 1.0F)
            hours = 1.0F;        // minimum charge.
        return (hours * billingRate);
    }

    public new string TypeName()
    {
        return ("Civil Employee");
    }
}

class MainClasss
{
    public static void Main()
    {
        Employee[] earray = new Employee[2];
        earray[0] = new Employee("A", 15.50F);
        earray[1] = new Manager("B", 40F);

        Console.WriteLine("{0} charge = {1}",
        earray[0].TypeName(),
        earray[0].CalculateCharge(2F));
        Console.WriteLine("{0} charge = {1}",
        earray[1].TypeName(),
        earray[1].CalculateCharge(0.75F));
    }
}
//Employee charge = 31
//Civil Employee charge = 40