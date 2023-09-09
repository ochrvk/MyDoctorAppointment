using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        //additional methods can be added here
    }
}
