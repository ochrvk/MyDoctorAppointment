using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string PathJSON { get; set; }
        public abstract string PathXML { get; set; }

        public abstract int LastId { get; set; }

        public TSource Create(TSource source, DataFormat dataFormat)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            if (dataFormat == DataFormat.Json)
            {
                File.WriteAllText(PathJSON,
                    JsonConvert.SerializeObject(GetAll(dataFormat).Append(source), Formatting.Indented));
            }
            else
            {
                throw new NotImplementedException();
            }
            return source;
        }

        public bool Delete(int id, DataFormat dataFormat)
        {
            if (GetById(id, dataFormat) is null)
            {
                return false;
            }

            if (dataFormat == DataFormat.Json)
            {
                File.WriteAllText(PathJSON,
                    JsonConvert.SerializeObject(GetAll(dataFormat).Where(x => x.Id != id),
                        Formatting.Indented));
            }
            else
            {

            }

            return true;
        }

        public IEnumerable<TSource> GetAll(DataFormat dataFormat)
        {
            if (dataFormat == DataFormat.Json)
            {
                if (!File.Exists(PathJSON))
                {
                    File.WriteAllText(PathJSON, "[]");
                }

                var json = File.ReadAllText(PathJSON);

                if (string.IsNullOrWhiteSpace(json))
                {
                    File.WriteAllText(PathJSON, "[]");
                    json = "[]";
                }

                return JsonConvert.DeserializeObject<List<TSource>>(json)!;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public TSource? GetById(int id, DataFormat dataFormat)
        {
            if (dataFormat == DataFormat.Json)
            {
                return GetAll(dataFormat).FirstOrDefault(x => x.Id == id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public TSource Update(int id, TSource source, DataFormat dataFormat)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;
            if (dataFormat == DataFormat.Json)
            {
                File.WriteAllText(PathJSON,
                    JsonConvert.SerializeObject(GetAll(dataFormat).Select(x => x.Id == id ? source : x),
                        Formatting.Indented));
            }
            else
            {
                throw new NotImplementedException();
            }


            return source;
        }

        protected abstract void SaveLastId(DataFormat dataFormat);

        protected dynamic? ReadFromAppSettings() =>
            JsonConvert.DeserializeObject<dynamic>
                (File.ReadAllText(Constants.AppSettingsPath));
    }
}
