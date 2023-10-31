using Sureze.Domain.Entities;
using Sureze.Repositories;

namespace Sureze.Specifications
{
    public class PatientAddressesSpecifications : BaseSpecifcation<PatientAddresses>
    {
        public PatientAddressesSpecifications(long PatientsId)
        {
            Criteria = i => i.PatientsId == PatientsId;

        }
    }

}
