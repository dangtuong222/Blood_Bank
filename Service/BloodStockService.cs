using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class BloodStockService
    {
        private readonly BloodStockRepository _repository;

        public BloodStockService()
        {
            _repository = new BloodStockRepository();
        }

        public DataTable GetBloodStock()
        {
            return _repository.GetBloodStock();
        }
    }
}
