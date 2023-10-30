using System.Net;
using Sureze.Domain.Contextes;
using Sureze.Domain.Entities;
using Sureze.Helpers;
using Sureze.Services;
using Sureze.Specifications;

namespace Sureze.Methods
{

    public class PatientsClass
    {
        readonly IServiceFactory _services;
        public IConfiguration _configuration;
        public StateContainer _stateContainer;
        public ApplicationDbContext _Context;
        public PatientsClass(IServiceFactory service, IConfiguration config, StateContainer StateContainer, ApplicationDbContext ApplicationDbContext)
        {
            _services = service;
            _configuration = config;
            _stateContainer = StateContainer;
            _Context = ApplicationDbContext;
        }



        public async Task<Patients> NewPatient(Patients R)
        {
         

            R.CreateAt = DateTime.Now;
            var x = await _services.PatientsService.Create(R);
            await _services.SaveAsync();
            _stateContainer.activeuserid = x.Id;
            return x;
        }


        public async Task<PatientAddresses> NewPatientAddresses(PatientAddresses R)
        {
            R.Id = 0;
            R.CreateAt = DateTime.Now;
            var x = await _services.PatientAddressesService.Create(R);
            await _services.SaveAsync();
            return x;
        }



        public async Task<Patients> GetPatientById(long id)
        {

            var x = await _services.PatientsService.ReadById(id);

            return x;
        }



        public async Task<List<Patients>> GetPatients()
        {
      
            var x = await _services.PatientsService.ReadAll();

            return x.ToList();
        }


        public async Task<List<PatientAddresses>> GetPatientAddresses(long id)
        {
      
            var x = await _services.PatientAddressesService.ReadAll(new PatientAddressesSpecifications(id));

            return x.ToList();
        }

        public async Task<ResponseHandling> UpdatePatientAddresses(PatientAddresses pa)
        {
      
           await _services.PatientAddressesService.Update(pa);
           await _services.SaveAsync();
           return new ResponseHandling(HttpStatusCode.OK);

        }
        public async Task<ResponseHandling> UpdatePatient(Patients p)
        {
      
           await _services.PatientsService.Update(p);
           await _services.SaveAsync();
           return new ResponseHandling(HttpStatusCode.OK);

        }  
        
        public async Task<ResponseHandling> DeletePatient(Patients Patients)
        {
      
           await _services.PatientsService.Remove(Patients);
           await _services.SaveAsync();
           return new ResponseHandling(HttpStatusCode.OK);

        }

    }
}
