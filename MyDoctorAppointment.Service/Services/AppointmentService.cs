using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extensions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
            dataFormat = DataFormat.Json;
        }

        private readonly IAppointmentRepository _appointmentRepository;

        public DataFormat dataFormat { get; set; }

        public AppointmentViewModel Create(Appointment appointment)
        {
            var appointments = _appointmentRepository.Create(appointment, dataFormat);
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id, dataFormat);
        }

        public AppointmentViewModel? Get(int id)
        {
            var appointments = _appointmentRepository.GetById(id, dataFormat)!;
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            var appointments = _appointmentRepository.GetAll(dataFormat);
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public AppointmentViewModel Update(int id, Appointment appointment)
        {
            var appointments = _appointmentRepository.Update(id, appointment, dataFormat);
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public void ShowInfo(AppointmentViewModel appointmentViewModels)
        {

            Console.WriteLine("Patient: " + appointmentViewModels.Patient!.Name
                + " " + appointmentViewModels.Patient.Surname);
            Console.WriteLine("Doctor: " + appointmentViewModels.Doctor!.Name
                + " " + appointmentViewModels.Doctor.Surname);

            Console.WriteLine("Appointment date: " + appointmentViewModels.DateTimeForm);

            Console.WriteLine("Description: " + appointmentViewModels.Description);
        }
    }
}
