using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class DashboardService
    {
        private readonly DashboardRepository _repository;

        public DashboardService()
        {
            _repository = new DashboardRepository();
        }

        public int GetDonorCount()
        {
            return _repository.GetDonorCount();
        }

        public int GetTransferCount()
        {
            return _repository.GetTransferCount();
        }

        public int GetEmployeeCount()
        {
            return _repository.GetEmployeeCount();
        }

        public int GetBloodStock()
        {
            return _repository.GetBloodStock();
        }

        public int GetBloodGroupCount(string bloodGroup)
        {
            return _repository.GetBloodGroupCount(bloodGroup);
        }

        // Tính phần trăm máu theo nhóm máu
        public int GetBloodGroupPercentage(string bloodGroup, int totalStock)
        {
            int count = GetBloodGroupCount(bloodGroup);
            return totalStock > 0 ? (count * 100) / totalStock : 0;
        }
    }
}
