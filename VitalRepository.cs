using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PatientVitalTracker
{
    public class VitalRepository
    {
       private readonly string _filePath;
       private readonly DataStore _data;

       public VitalRepository(string filePath = "data.json")
        {
            _filePath = filePath;
            _data = LoadFromFile();
        } 

        public IReadOnlyList<Patient> GetPatients() => _data.Patients;
        public IReadOnlyList<VitalReading> GetReadings() => _data.Readings;

        public Patient AddPatient(string name, int age)
        {
            int newId = _data.Patients.Any() ? _data.Patients.Max(p => p.Id) + 1 : 1;

            var patient = new Patient
            {
                Id = newId,
                Name = name,
                Age = age
            };

            _data.Patients.Add(patient);
            SaveToFile();
            return patient;
        }

        public Patient? GetPatientById(int id)
        {
            return _data.Patients.FirstOrDefault(p => p.Id == id);
        }

        public VitalReading AddReading(int patientId, VitalType type, double value)
        {
            var reading = new VitalReading
            {
                PatientId = patientId,
                Type = type,
                Value = value,
                RecordedAt = System.DateTime.Now
            };

            _data.Readings.Add(reading);
            SaveToFile();
            return reading;
        }

        public IEnumerable<VitalReading> GetReadingsForPatient(int patientId)
        {
            return _data.Readings.Where(r => r.PatientId == patientId).OrderByDescending(r => r.RecordedAt);
        }

        private DataStore LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new DataStore();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<DataStore>(json);

                return data ?? new DataStore();
            }
            catch
            {
                return new DataStore(); // If file corrupted or invalid JSON, start fresh
            }
        }

        private void SaveToFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(_data, options);
            File.WriteAllText(_filePath, json);
        }
    }
}