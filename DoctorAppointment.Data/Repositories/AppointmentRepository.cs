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

            PathJSON = result!.Database.Appointments.PathJSON;
            PathXML = result!.Database.Appointments.PathXML;
            LastId = result.Database.Appointments.LastId;
        }

        public override string PathJSON { get; set; }
        public override string PathXML { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId()
        {
            dynamic? result = ReadFromAppSettings();
            result!.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());

        }
    }
}
