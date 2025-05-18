using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class BloodTransferService
    {
        private readonly BloodTransferRepository _repository;

        public BloodTransferService()
        {
            _repository = new BloodTransferRepository();
        }

        // Lấy danh sách bệnh nhân
        public DataTable GetAllPatients()
        {
            return _repository.GetPatients();
        }

        // Lấy thông tin bệnh nhân theo ID
        public DataTable GetPatientDetails(string patientId)
        {
            return _repository.GetPatientById(patientId);
        }

        // Kiểm tra xem máu có sẵn không
        public bool CheckStockAvailability(string bloodGroup)
        {
            int stock = _repository.GetBloodStockByGroup(bloodGroup);
            return stock > 0;
        }

        // Xử lý việc chuyển máu và cập nhật số lượng máu
        public void ProcessBloodTransfer(string bloodGroup)
        {
            int currentStock = _repository.GetBloodStockByGroup(bloodGroup);
            if (currentStock > 0)
            {
                _repository.UpdateBloodStock(bloodGroup, currentStock - 1);  // Giảm số lượng máu
            }
            else
            {
                throw new InvalidOperationException("Insufficient stock available.");
            }
        }

        // Thực hiện việc chèn thông tin chuyển máu vào bảng TransferTbl
        public void RecordBloodTransfer(string patientName, string bloodGroup)
        {
            _repository.InsertBloodTransfer(patientName, bloodGroup);
        }
    }
}
