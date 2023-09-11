using MyDoctorAppointment.Data.Enums;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {

        TSource Create(TSource source, DataFormat dataFormat);

        TSource? GetById(int id, DataFormat dataFormat);

        TSource Update(int id, TSource source, DataFormat dataFormat);

        IEnumerable<TSource> GetAll(DataFormat dataFormat);

        bool Delete(int id, DataFormat dataFormat);
    }
}
