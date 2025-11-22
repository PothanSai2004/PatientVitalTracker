using System;
using System.Linq;

namespace PatientVitalTracker
{
    public class App
    {
        private readonly VitalRepository _repo;

        public App()
        {
            _repo = new VitalRepository();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Patient Vital Tracker ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. List Patients");
                Console.WriteLine("3. Add Vital Reading");
                Console.WriteLine("4. View Patient Readings");
                Console.WriteLine("5. View Latest Reading Summary");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        ListPatients();
                        break;
                    case "3":
                        AddVitalReading();
                        break;
                    case "4":
                        ViewPatientReadings();
                        break;
                    case "5":
                        ViewLatestReadingsSummary();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewLatestReadingsSummary()
        {
            Console.Clear();
            Console.WriteLine("=== Latest Reading Summary ===");

            var patients = _repo.GetPatients();

            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }

            foreach (var p in patients)
            {
                // Get the latest reading for this patient (GetReadingsForPatient returns newest first)
                var latestReading = _repo.GetReadingsForPatient(p.Id).FirstOrDefault();

                if (latestReading == null)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age} | No readings yet.");
                }
                else
                {
                    Console.WriteLine(
                        $"Id: {p.Id}, Name: {p.Name}, Age: {p.Age} | " +
                        $"{latestReading.Type} = {latestReading.Value} at {latestReading.RecordedAt:g}");
                }
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("=== Add Patient ===");

            Console.Write("Name: ");
            string? name = Console.ReadLine();

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            var patient = _repo.AddPatient(name ?? "", age);

            Console.WriteLine($"Patient added with Id: {patient.Id}");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void ListPatients()
        {
            Console.Clear();
            Console.WriteLine("=== Patients ===");

            var patients = _repo.GetPatients();

            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                foreach (var p in patients)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}");
                }
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void AddVitalReading()
        {
            Console.Clear();
            Console.WriteLine("=== Add Vital Reading ===");

            Console.Write("Enter Patient Id: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid Id. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            var patient = _repo.GetPatientById(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Selected Patient: {patient.Name}");

            Console.WriteLine("Choose Vital Type:");
            Console.WriteLine("1. Heart Rate (bpm)");
            Console.WriteLine("2. Systolic Blood Pressure (mmHg)");
            Console.WriteLine("3. Diastolic Blood Pressure (mmHg)");
            Console.WriteLine("4. Temperature (°C)");
            Console.WriteLine("5. Respiratory Rate (bpm)");
            Console.Write("Option: ");

            if (!int.TryParse(Console.ReadLine(), out int vitalChoice) ||
                vitalChoice < 1 || vitalChoice > 5)
            {
                Console.WriteLine("Invalid vital type. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            VitalType type = (VitalType)vitalChoice;

            Console.Write("Enter value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Invalid value. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            var reading = _repo.AddReading(patientId, type, value);

            Console.WriteLine("Reading recorded.");
            PrintSimpleAlert(reading, patient);
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void ViewPatientReadings()
        {
            Console.Clear();
            Console.WriteLine("=== View Patient Readings ===");

            Console.Write("Enter Patient Id: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid Id. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            var patient = _repo.GetPatientById(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found. Press Enter to go back.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Patient: {patient.Name} (Age {patient.Age})");

            var readings = _repo.GetReadingsForPatient(patientId).ToList();

            if (!readings.Any())
            {
                Console.WriteLine("No readings found for this patient.");
            }
            else
            {
                foreach (var r in readings)
                {
                    Console.WriteLine($"{r.RecordedAt:g} | {r.Type} | {r.Value}");
                }
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void PrintSimpleAlert(VitalReading reading, Patient patient)
        {
            string message = reading.Type switch
            {
                VitalType.HeartRate => reading.Value switch
                {
                    < 60 => "Heart rate is low (bradycardia).",
                    > 100 => "Heart rate is high (tachycardia).",
                    _ => "Heart rate is within normal range."
                },
                VitalType.SystolicBP => reading.Value switch
                {
                    < 90 => "Systolic BP is low.",
                    > 140 => "Systolic BP is high.",
                    _ => "Systolic BP is in normal range."
                },
                VitalType.DiastolicBP => reading.Value switch
                {
                    < 60 => "Diastolic BP is low.",
                    > 90 => "Diastolic BP is high.",
                    _ => "Diastolic BP is in normal range."
                },
                VitalType.Temperature => reading.Value switch
                {
                    < 36.0 => "Temperature is low.",
                    > 37.5 => "Possible fever.",
                    _ => "Temperature is normal."
                },
                VitalType.RespiratoryRate => reading.Value switch
                {
                    < 12.0 => "Respiratory rate is low (bradypnea).",
                    > 25.0 => "Respiratory rate is high (tachypnea).",
                    _ => "Respiratory rate is normal (eupnea)."
                },
                _ => "No rule defined."
            };

            Console.WriteLine($"Alert for {patient.Name}: {message}");
        }
    }
}
