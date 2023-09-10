using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        PatientViewModel Create(Patient patient);

        IEnumerable<PatientViewModel> GetAll();

        PatientViewModel? Get(int id);

        bool Delete(int id);

        PatientViewModel Update(int id, Patient patient);

        void ShowInfo(Patient patient);
    }
}
