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

        public Doctor? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Doctor Update(int id, Doctor doctor)
        {
            doctor.UpdatedAt = DateTime.Now;
            doctor.Id = id;

            File.WriteAllText(Path,
                JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? doctor : x),
                    Formatting.Indented));

            return doctor;
        }

        public IEnumerable<Doctor> GetAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var json = File.ReadAllText(Path);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<Doctor>>(json);
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
            {
                return false;
            }

            File.WriteAllText(Path,
                JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id),
                    Formatting.Indented));

            return true;
        }

        private dynamic? ReadFromAppSettings() =>
            JsonConvert.DeserializeObject<dynamic>
                (File.ReadAllText(Constants.AppSettingsPath));
    }
}
