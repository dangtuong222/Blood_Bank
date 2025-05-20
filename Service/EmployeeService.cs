using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class EmployeeService
    {
        private readonly EmployeeRepository _repository;
        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public DataTable GetEmployees()
        {
            return _repository.GetAllEmployees();
        }

        public void AddEmployee(string empId, string empPass)
        {
            if (string.IsNullOrWhiteSpace(empId) || string.IsNullOrWhiteSpace(empPass))
            {
                throw new ArgumentException("Missing Information");
            }
            _repository.InsertEmployee(empId, empPass);
        }
    }
}
