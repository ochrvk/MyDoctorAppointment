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

        public DoctorViewModel Create(Doctor doctor)
        {
            var doctors = _doctorRepository.Create(doctor);
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public DoctorViewModel? Get(int id)
        {
            var doctors = _doctorRepository.GetById(id)!;
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public DoctorViewModel Update(int id, Doctor doctor)
        {
            var doctors = _doctorRepository.Update(id, doctor);
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public void ShowInfo(Doctor doctor)
        {
            var doctorViewModel = doctor.ConvertTo();
            Console.WriteLine("Doctor name: " + doctorViewModel.Name);
            Console.WriteLine("Doctor surname: " + doctorViewModel.Surname);
            Console.WriteLine("Doctor email: " + doctorViewModel.Email);
            Console.WriteLine("Doctor phone: " + doctorViewModel.Phone);
            Console.WriteLine("Doctor type: " + doctorViewModel.DoctorType);
            Console.WriteLine("Doctor experiance: " + doctorViewModel.Experiance);
            Console.WriteLine("Doctor salary: " + doctorViewModel.Salary);
        }
    }
}
