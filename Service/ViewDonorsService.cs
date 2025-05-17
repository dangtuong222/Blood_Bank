using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class ViewDonorsService
    {
        private readonly ViewDonorsRepository _repository;
        public ViewDonorsService()
        {
            _repository = new ViewDonorsRepository();
        }


        public DataTable GetDonors()
        {
            return _repository.GetAllDonors();
        }
    }
}
