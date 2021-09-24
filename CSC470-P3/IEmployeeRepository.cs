using System;
using System.Collections.Generic;
using System.Text;

namespace CSC470_P3
{
    public interface IEmployeeRepository
    {
        int Save(Employee Emp);
        List<Employee> GetAll();
        decimal GetSalary(int Id);
    }
}
