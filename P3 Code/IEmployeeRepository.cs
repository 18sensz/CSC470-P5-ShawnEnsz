using System;
using System.Collections.Generic;
using System.Text;

namespace P3_Code
{
    public interface IEmployeeRepository
    {
        int Save(Employee Emp);
        List<Employee> GetAll();
        decimal GetSalary(int Id);
    }
}
