using Sureze.Repositories;

namespace Sureze.Services
{
    public interface IServiceFactory
    {
        Guid Apikey { get; set; }
        public PatientsService PatientsService { get;  }
        public PatientAddressesService PatientAddressesService { get;  }
 
        Task<int> SaveAsync();

    }

    public class ServiceFactory : IDisposable, IServiceFactory
    {
        private bool disposed = false;

        public Guid Apikey { get; set; }
        private readonly IRepositoryFactory _factory;
        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _factory = repositoryFactory;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ((IDisposable)_factory).Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private PatientsService _PatientsService;
        public PatientsService PatientsService
        {
            get
            {
                return this._PatientsService ??= new PatientsService(_factory,this.Apikey);
            }
        }

        private PatientAddressesService _PatientAddressesService;
        public PatientAddressesService PatientAddressesService
        {
            get
            {
                return this._PatientAddressesService ??= new PatientAddressesService(_factory,this.Apikey);
            }
        }

       



        public async Task<int> SaveAsync()
        {
            try
            {
                return await _factory.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
