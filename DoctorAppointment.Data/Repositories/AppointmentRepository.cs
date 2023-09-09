using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository()
        {
            dynamic? result = ReadFromAppSettings();

            Path = result!.Database.Appointment.Path;
            LastId = result.Database.Appointment.LastId;
        }

        public override string Path { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId()
        {
            dynamic? result = ReadFromAppSettings();
            result!.Database.Appointment.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
