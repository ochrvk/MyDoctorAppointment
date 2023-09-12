using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        public DataFormat dataFormat { get; set; }

        DoctorViewModel Create(Doctor doctor);

        IEnumerable<DoctorViewModel> GetAll();

        DoctorViewModel? Get(int id);

        bool Delete(int id);

        DoctorViewModel Update(int id, Doctor doctor);

        void ShowInfo(Doctor doctor);
    }
}
