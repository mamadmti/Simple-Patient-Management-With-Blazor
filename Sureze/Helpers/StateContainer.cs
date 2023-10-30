
using Sureze.Domain.Entities;

namespace Sureze.Helpers
{
    public class StateContainer
    {
        private string? savedString;

        public string Property
        {
            get => savedString ?? string.Empty;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }

     

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        //public conversation con = new conversation();
        //public getchathistory gc = new getchathistory();

        public string token = "";

        public void StateChange()
        {
            NotifyStateChanged();
            
        }

        public long activeuserid = 0;

        public bool Patients = true;
        public bool PatientAddresses = false;

        public void UpdateHeading()
        {
            Patients = !Patients;
            PatientAddresses = !PatientAddresses;
            NotifyStateChanged();
        }

        public Patients EditPatient = new Patients();
    }
}
