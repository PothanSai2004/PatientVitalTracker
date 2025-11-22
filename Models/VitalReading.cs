using System;

namespace PatientVitalTracker
{
    public class VitalReading
    {
        public int PatientId { get; set; }
        public VitalType Type { get; set; }
        public double Value { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}