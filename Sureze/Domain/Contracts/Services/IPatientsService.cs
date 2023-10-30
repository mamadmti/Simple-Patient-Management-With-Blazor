
using Sureze.Domain.Contracts.Repositories;
using Sureze.Domain.Entities;

namespace Chat.Domain.Contracts.Services
{
    public interface IPatientsService : IService<Patients, long>
    {
	    Task<IEnumerable<long?>> GetUniqueIds();

		Task<long> GetCount<T>(ISpecification<T> specification = null) where T : BaseEntity;

	}
}
