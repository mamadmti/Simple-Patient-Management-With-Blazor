using Chat.Domain.Contracts.Services;
using Sureze.Domain.Contracts.Repositories;
using Sureze.Domain.Entities;
using Sureze.Repositories;

namespace Sureze.Services
{
    public class PatientsService:IPatientsService
    {
        private IRepositoryFactory _repository;
        public PatientsService(IRepositoryFactory repository, Guid? apikey)
        {
            _repository = repository;
            _repository.Repository.ApiKey = apikey;
        }
        public async Task<Patients> Create(Patients item)
        {
            return await _repository.Repository.Create<Patients>(item);
        }

        public async Task CreateRange(ICollection<Patients> entity)
        {
            await _repository.Repository.CreateRange<Patients>(entity);
        }


        public async Task<IEnumerable<Patients>> ReadAll( ISpecification<Patients> specification = null, int? skip = null, int? take = null)
        {
            return await _repository.Repository.ReadAll<Patients>(specification, skip, take);

        }

        public async Task<Patients> ReadById(long id)
        {
            return await _repository.Repository.ReadById<Patients>(id);
        }

        public async Task Update(Patients entity)
        {
            await _repository.Repository.Update(entity);
        }

        public async Task UpdateRange(ICollection<Patients> entity)
        {
            await _repository.Repository.UpdateRange(entity.ToList());
        }


        public async Task Remove(Patients item)
        {
            await _repository.Repository.Remove(item);
        }

        public async Task RemoveRange(IEnumerable<Patients> items)
        {
            await _repository.Repository.RemoveRange(items);
        }

        public async Task<IEnumerable<long?>> GetUniqueIds()
        { 
	       return await _repository.Repository.GetUniqueIds();
		}

        public async Task<long> GetCount<T>(ISpecification<T> specification = null) where T : BaseEntity
        {
			return await _repository.Repository.GetCount(specification);
		}


    }
}
