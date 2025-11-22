using System.Collections.Generic;

namespace PatientVitalTracker
{
    public class DataStore
    {
        public List<Patient> Patients { get; set; } = new();
        public List<VitalReading> Readings { get; set; } = new();
    }
}