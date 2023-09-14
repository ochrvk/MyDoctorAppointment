using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository()
        {
            dynamic? result = ReadFromAppSettings();

            PathJSON = result!.Database.Doctors.PathJSON;
            PathXML = result!.Database.Doctors.PathXML;
            LastId = result.Database.Doctors.LastId;
        }

        public override string PathJSON { get; set; }
        public override string PathXML { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId()
        {
            dynamic? result = ReadFromAppSettings();
            result!.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());

        }
    }
}
