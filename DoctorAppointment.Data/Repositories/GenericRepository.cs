using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Xml.Serialization;

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
            SaveLastId();
            if (dataFormat == DataFormat.Json)
            {
                File.WriteAllText(PathJSON,
                    JsonConvert.SerializeObject(GetAll(dataFormat).Append(source), Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                var sources = GetAll(dataFormat).ToList();
                sources.Add(source);
                SaveToXml(sources, PathXML);
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
                        Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                var sources = GetAll(dataFormat).Where(x => x.Id != id).ToList();
                SaveToXml(sources, PathXML);
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
                if (!File.Exists(PathXML))
                {
                    File.WriteAllText(PathXML, "<ArrayOf" + typeof(TSource).Name + "></ArrayOf" + typeof(TSource).Name + ">");
                }

                using (var fileStream = new FileStream(PathXML, FileMode.Open))
                {
                    var xmlSerializer = new XmlSerializer(typeof(List<TSource>));
                    var sources = (List<TSource>)xmlSerializer.Deserialize(fileStream)!;
                    return sources;
                }
            }
        }

        public TSource? GetById(int id, DataFormat dataFormat)
        {
            return GetAll(dataFormat).FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source, DataFormat dataFormat)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;
            if (dataFormat == DataFormat.Json)
            {
                File.WriteAllText(PathJSON,
                    JsonConvert.SerializeObject(GetAll(dataFormat).Select(x => x.Id == id ? source : x),
                        Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                var sources = GetAll(dataFormat).Select(x => x.Id == id ? source : x).ToList();
                SaveToXml(sources, PathXML);
            }
            return source;
        }

        protected abstract void SaveLastId();

        protected dynamic? ReadFromAppSettings() =>
            JsonConvert.DeserializeObject<dynamic>
                (File.ReadAllText(Constants.AppSettingsPath));


        private void SaveToXml(List<TSource> sources, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<TSource>));
                xmlSerializer.Serialize(fileStream, sources);
                fileStream.Close();
            }
            
        }
    }
}
