using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class LoginService
    {
        private readonly LoginRepository _repository;

        public LoginService()
        {
            _repository = new LoginRepository();
        }

        public bool AuthenticateEmployee(string empId, string empPass)
        {
            if (string.IsNullOrWhiteSpace(empId) || string.IsNullOrWhiteSpace(empPass))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            return _repository.ValidateEmployeeCredentials(empId, empPass);
        }
    }
}
