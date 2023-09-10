using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        AppointmentViewModel Create(Appointment appointment);

        IEnumerable<AppointmentViewModel> GetAll();

        AppointmentViewModel? Get(int id);

        bool Delete(int id);

        AppointmentViewModel Update(int id, Appointment appointment);

        void ShowInfo(Appointment appointment);
    }
}
