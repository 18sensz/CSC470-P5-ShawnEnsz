using System;
using System.Collections.Generic;
using System.Text;

namespace P3_Code
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private static Dictionary<int, Employee> Employees;

        public FakeEmployeeRepository()
        {
            if(Employees == null)
            {
                Employees = new Dictionary<int, Employee>();
                //Default Employees to wwork with
                Employees.Add(1, new Employee
                {
                    Id = 1,
                    LastName = "Ensz",
                    FirstName = "Shawn",
                    Salary = 1337.69M,
                });
                Employees.Add(2, new Employee
                {
                    Id = 2,
                    LastName = "Bishop",
                    FirstName = "Dave",
                    Salary = 99999.69M,
                });
            }
        }
         private int GetNextId()
        {
            int curMaxId = 0;
            foreach(KeyValuePair<int, Employee> keyValPair in Employees)
            {
                if(keyValPair.Key > curMaxId)
                {
                    curMaxId = keyValPair.Key;
                }
            }
            return ++curMaxId;
        }

        public int Save(Employee Emp)
        {
            int Id = GetNextId();
            Emp.Id = Id;
            Employees.Add(Emp.Id, Emp);
            return Id;
        }

        public List<Employee> GetAll()
        {
            List<Employee> emps = new List<Employee>();
            foreach(KeyValuePair<int, Employee> emp in Employees)
            {
                emps.Add(emp.Value);
            }
            return emps;
        }
        public decimal GetSalary(int Id)
        {
            decimal salary = -1.0M;
            Employee emp;
            if(Employees.TryGetValue(Id, out emp))
            {
                salary = emp.Salary;
            }
            return salary;
        }
        public Employee GetById(int Id)
        {
            Employee emp;
            bool ignore = Employees.TryGetValue(Id, out emp);
            return emp;
        }

    }
}
