using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository()
        {
            dynamic? result = ReadFromAppSettings();

            PathJSON = result!.Database.Patients.PathJSON;
            PathXML = result!.Database.Patients.PathXML;
            LastId = result.Database.Patients.LastId;
        }

        public override string PathJSON { get; set; }
        public override string PathXML { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId()
        {
            dynamic? result = ReadFromAppSettings();
            result!.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
