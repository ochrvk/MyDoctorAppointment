using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public string Path { get; set; }

        public int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        private void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.toString());
        }

        public Doctor Create(Doctor doctor)
        {
            doctor.Id = ++LastId;
            doctor.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(doctor), Formatting.Indented));
            SaveLastId();
            return doctor;
        }

        public Doctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor Update(int id, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        private dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));
    }
}
