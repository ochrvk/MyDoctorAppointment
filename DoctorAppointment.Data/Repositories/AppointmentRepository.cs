using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository()
        {
            dynamic? result = ReadFromAppSettings();

            PathJSON = result!.Database.Appointment.PathJSON;
            PathXML = result!.Database.Appointment.PathXML;
            LastId = result.Database.Appointment.LastId;
        }

        public override string PathJSON { get; set; }
        public override string PathXML { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId(DataFormat dataFormat)
        {
            if (dataFormat == DataFormat.Json)
            {
                dynamic? result = ReadFromAppSettings();
                result!.Database.Appointment.LastId = LastId;

                File.WriteAllText(Constants.AppSettingsPath, result.ToString());
            }
            else
            {
                throw new NotImplementedException();
            }

        }
    }
}
