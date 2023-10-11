using System.ComponentModel.Design.Serialization;
using System.Text.Json.Serialization.Metadata;

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName,decimal salary)
    {
        IEmployee employee = null;

        switch(employeeType)
        {
            case EmployeeType.Teacher :
            employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
            //This will be the old way to create an instance of class Teacher
            // However, in factory method, the classes dont have constuctors
            // An object from the class can only be constructed using Factory Class 
            //employee = new Teacher(id,firstName,lastName,salary);
            break;

            case EmployeeType.DeputyHeadMaster:
            employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
            break;

            case EmployeeType.HeadOfDepartment:
            employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
            break;

            case EmployeeType.HeadMaster :
            employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
            break;

            default:
            break;
        }
            if(employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary  = salary;
            }
            else
            {
                throw new NullReferenceException();
            }
    return employee;
    }

}

public enum EmployeeType
    { 
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }

    public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02M);}

    //public Teacher(int id, string firstname, string lastname, decimal salary)
    //{}
}

public class HeadOfDepartment: EmployeeBase
{
    public override decimal Salary{get =>base.Salary + (base.Salary*0.03M);}
}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary{get => base.Salary + (base.Salary*0.04M);}
}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary{get => base.Salary + (base.Salary*0.05M);}
}




