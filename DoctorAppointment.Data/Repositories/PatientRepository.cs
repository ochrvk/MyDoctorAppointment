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

            Path = result!.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override string Path { get; set; }

        public override int LastId { get; set; }

        protected override void SaveLastId()
        {
            dynamic? result = ReadFromAppSettings();
            result!.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
