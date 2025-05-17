using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_Bank.Data;

namespace Blood_Bank.Service
{
    internal class ViewPatientsService
    {
        private readonly ViewPatientsRepository _repository;

        public ViewPatientsService()
        {
            _repository = new ViewPatientsRepository();
        }

        public DataTable GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        public void DeletePatient(int key)
        {
            _repository.DeletePatient(key);
        }

        public void UpdatePatient(int key, string name, int age, string phone, string gender, string bloodGroup, string address)
        {
            if (key <= 0)
                throw new ArgumentException("Invalid patient selected.");

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(bloodGroup) || string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Missing information");
            }

            _repository.UpdatePatient(key, name, age, phone, gender, bloodGroup, address);
        }

        public void DeletePatientData(int key)
        {
            if (key == 0)
            {
                throw new ArgumentException("Select the Patient to be deleted");
            }

            _repository.DeletePatient(key);
        }
    }
}
