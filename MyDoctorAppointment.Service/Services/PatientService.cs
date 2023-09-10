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

        public PatientViewModel Create(Patient patient)
        {
            var patients = _patientRepository.Create(patient);
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public PatientViewModel? Get(int id)
        {
            var patients = _patientRepository.GetById(id)!;
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _patientRepository.GetAll();
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }

        public PatientViewModel Update(int id, Patient patient)
        {
            var patients = _patientRepository.Update(id, patient);
            var patientViewModels = patients.ConvertTo();
            return patientViewModels;
        }

        public void ShowInfo(Patient patient)
        {
            var patientViewModels = patient.ConvertTo();
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
