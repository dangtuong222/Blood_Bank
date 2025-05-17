using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    public class DonorService
    {
        private readonly DonorRepository _donorRepository;

        public DonorService()
        {
            _donorRepository = new DonorRepository();
        }

        public void AddDonor(string name, string ageText, string gender, string phone, string address, string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(name) ||
               string.IsNullOrWhiteSpace(ageText) ||
               string.IsNullOrWhiteSpace(phone) ||
               string.IsNullOrWhiteSpace(gender) ||
               string.IsNullOrWhiteSpace(bloodGroup))
            {
                throw new ArgumentException("Missing information");
            }

            if (!int.TryParse(ageText, out int age))
            {
                throw new ArgumentException("Age must be a valid number");
            }

            if (age <= 0 || age > 120)
            {
                throw new ArgumentException("Age must be between 1 and 120");
            }

            _donorRepository.InsertDonor(name, age, gender, phone, address, bloodGroup);
        }
    }
}
