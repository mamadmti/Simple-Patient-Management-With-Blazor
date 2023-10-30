namespace Sureze.Domain.Entities
{
    public class PatientAddresses: BaseEntity
    {

        public string address { get; set; }
        public string country { get; set; }
        public string phonenumber { get; set; }
        public string postalCode { get; set; }
        public Patients Patients { get; set; }
        public long PatientsId { get; set; }

    }
}
