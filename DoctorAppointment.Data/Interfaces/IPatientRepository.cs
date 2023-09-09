using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
        //additional methods can be added here
    }
}
