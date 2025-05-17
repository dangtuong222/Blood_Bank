using System;
using System.Data;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    public class DonateBloodService
    {
        private readonly DonateBloodRepository _repository;

        public DonateBloodService()
        {
            _repository = new DonateBloodRepository();
        }

        public DataTable GetDonors()
        {
            return _repository.GetDonors();
        }

        public DataTable GetBloodStock()
        {
            return _repository.GetBloodStock();
        }

        public int GetCurrentStock(string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(bloodGroup))
                throw new ArgumentException("Blood group cannot be empty.");

            return _repository.GetStockByGroup(bloodGroup);
        }

        public void AddDonation(string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(bloodGroup))
                throw new ArgumentException("Blood group cannot be empty.");

            int currentStock = _repository.GetStockByGroup(bloodGroup);
            int newStock = currentStock + 1;

            _repository.UpdateStock(bloodGroup, newStock);
        }
    }
}
