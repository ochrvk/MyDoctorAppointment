using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extensions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        private readonly IPatientRepository _patientRepository;
        public DataFormat dataFormat { get; set; }

        public PatientViewModel Create(Patient patient)
        {
            var patients = _patientRepository.Create(patient, dataFormat);
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id, dataFormat);
        }

        public PatientViewModel? Get(int id)
        {
            var patients = _patientRepository.GetById(id, dataFormat)!;
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _patientRepository.GetAll(dataFormat);
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }

        public PatientViewModel Update(int id, Patient patient)
        {
            var patients = _patientRepository.Update(id, patient, dataFormat);
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public void ShowInfo(PatientViewModel patientViewModels)
        {
            Console.WriteLine("Patient name: " + patientViewModels.Name);
            Console.WriteLine("Patient surname: " + patientViewModels.Surname);
            Console.WriteLine("Patient email: " + patientViewModels.Email);
            Console.WriteLine("Patient phone: " + patientViewModels.Phone);
            Console.WriteLine("Patient Address: " + patientViewModels.Address);
            Console.WriteLine("Illness Type: " + patientViewModels.IllnessType);
            Console.WriteLine("Additional info: " + patientViewModels.AdditionalInfo);
        }
    }
}
