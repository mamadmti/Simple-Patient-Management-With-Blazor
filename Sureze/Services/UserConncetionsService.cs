using Chat.Domain.Contracts.Services;
using Sureze.Domain.Contracts.Repositories;
using Sureze.Domain.Entities;
using Sureze.Repositories;

namespace Sureze.Services
{
    public class PatientAddressesService : IPatientAddressesService
    {
        private IRepositoryFactory _repository;
        public PatientAddressesService(IRepositoryFactory repository, Guid? apikey)
        {
            _repository = repository;
            _repository.Repository.ApiKey = apikey;
        }

        public async Task<PatientAddresses> Create(PatientAddresses item)
        {
            return await _repository.Repository.Create<PatientAddresses>(item);
        }

        public  async Task CreateRange(ICollection<PatientAddresses> entity)
        {
            await _repository.Repository.CreateRange<PatientAddresses>(entity);
        }

        public   async Task<IEnumerable<PatientAddresses>> ReadAll( ISpecification<PatientAddresses> specification = null, int? skip = null, int? take = null)
        {
            return await _repository.Repository.ReadAll<PatientAddresses>(specification, skip, take);

        }

       

        public   async Task<PatientAddresses> ReadById(long id)
        {
            return await _repository.Repository.ReadById<PatientAddresses>(id);
        }

        public   async Task Update(PatientAddresses entity)
        {
            await _repository.Repository.Update(entity);
        }

        public   async Task UpdateRange(ICollection<PatientAddresses> entity)
        {
            await _repository.Repository.UpdateRange(entity.ToList());
        }

        public   async Task Remove(PatientAddresses item)
        {
            await _repository.Repository.Remove(item);
        }

        public   async Task RemoveRange(IEnumerable<PatientAddresses> items)
        {
            await _repository.Repository.RemoveRange(items);
        }
    }
}
