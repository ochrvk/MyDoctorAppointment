using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource entity);

        TSource GetById(int id);

        TSource Update(int id, TSource entity);

        IEnumerable<TSource> GetAll();

        bool Delete(int id);
    }
}
