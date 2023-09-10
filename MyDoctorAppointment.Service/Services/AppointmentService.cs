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
        }

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentViewModel Create(Appointment appointment)
        {
            var appointments = _appointmentRepository.Create(appointment);
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public AppointmentViewModel? Get(int id)
        {
            var appointments = _appointmentRepository.GetById(id)!;
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public AppointmentViewModel Update(int id, Appointment appointment)
        {
            var appointments = _appointmentRepository.Update(id, appointment);
            var appointmentViewModels = appointments.ConvertTo();
            return appointmentViewModels;
        }

        public void ShowInfo(Appointment appointment)
        {
            var appointmentViewModels = appointment.ConvertTo();

            Console.WriteLine("Patient: " + appointmentViewModels.Patient.Name
                + " " + appointmentViewModels.Patient.Surname);
            Console.WriteLine("Doctor: " + appointmentViewModels.Doctor.Name
                + " " + appointmentViewModels.Doctor.Surname);

            Console.WriteLine("Appointment date: " + appointmentViewModels.DateTimeForm);

            Console.WriteLine("Description: " + appointmentViewModels.Description);
        }
    }
}
