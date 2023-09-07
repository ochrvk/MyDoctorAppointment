using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public TSource Create(TSource entity) => throw new NotImplementedException();
        public bool Delete(int id) => throw new NotImplementedException();
        public IEnumerable<TSource> GetAll() => throw new NotImplementedException();
        public TSource GetById(int id) => throw new NotImplementedException();
        public TSource Update(int id, TSource entity) => throw new NotImplementedException();
    }
}
