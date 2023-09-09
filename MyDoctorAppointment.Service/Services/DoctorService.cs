using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extensions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }

        private readonly IDoctorRepository _doctorRepository;

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }
    }
}
