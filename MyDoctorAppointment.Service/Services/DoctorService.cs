using MyDoctorAppointment.Data.Enums;
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
        public DataFormat dataFormat { get; set; }

        public DoctorViewModel Create(Doctor doctor)
        {
            var doctors = _doctorRepository.Create(doctor, dataFormat);
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id, dataFormat);
        }

        public DoctorViewModel? Get(int id)
        {
            var doctors = _doctorRepository.GetById(id, dataFormat)!;
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll(dataFormat);
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public DoctorViewModel Update(int id, Doctor doctor)
        {
            var doctors = _doctorRepository.Update(id, doctor, dataFormat);
            var doctorViewModels = doctors.ConvertTo();
            return doctorViewModels;
        }

        public void ShowInfo(Doctor doctor)
        {
            var doctorViewModels = doctor.ConvertTo();
            Console.WriteLine("Doctor name: " + doctorViewModels.Name);
            Console.WriteLine("Doctor surname: " + doctorViewModels.Surname);
            Console.WriteLine("Doctor email: " + doctorViewModels.Email);
            Console.WriteLine("Doctor phone: " + doctorViewModels.Phone);
            Console.WriteLine("Doctor type: " + doctorViewModels.DoctorType);
            Console.WriteLine("Doctor experiance: " + doctorViewModels.Experiance);
            Console.WriteLine("Doctor salary: " + doctorViewModels.Salary);
        }
    }
}
