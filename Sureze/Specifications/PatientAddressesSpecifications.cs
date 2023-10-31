using Sureze.Domain.Entities;
using Sureze.Repositories;

namespace Sureze.Specifications
{
    public class PatientSpecifications : BaseSpecifcation<Patients>
    {
        public PatientSpecifications(string NatinalIdNumber)
        {
            Criteria = i => i.NatinalIdNumber == NatinalIdNumber;

        }
    }

}
