using System;
using System;
using Abp.Domain.Entities.Auditing;
using Sureze.Domain.Entities.Enums;


namespace Sureze.Domain.Entities
{
    public class Patients : BaseEntity
    {
        public PatientsEnums.PrimaryProvider PrimaryProvider { get; set; } = new PatientsEnums.PrimaryProvider();

        public PatientsEnums.Title Title { get; set; } = new PatientsEnums.Title();
        public string Suffix { get; set; } = "" ;
        public string FirstName { get; set; } = "" ;
        public string LastName { get; set; } = "" ;
        public string NatinalIdNumber { get; set; } = "" ;
        public DateTime Birthdate { get; set; } 

        public PatientsEnums.Sex Sex { get; set; }
        public PatientsEnums.Race Race { get; set; }
        public string profilepicture { get; set; } = "";
    }





}
