# 🩺 Patient Vital Tracker  
*A Beginner-Friendly .NET Console Application for Managing Patient Vital Readings*

---

## 📌 Overview

**Patient Vital Tracker** is a simple yet structured C#/.NET console application designed to help track patient details and their vital readings such as:

- ❤️ Heart Rate  
- 🩸 Blood Pressure (Systolic & Diastolic)  
- 🌡 Temperature  
- 🌬 Respiratory Rate  

This project follows clean code architecture with **Models**, **Repository Layer**, and **Application Layer**, making it an excellent demonstration project for interviews (including Medtronic 👀).

---

## ✨ Features

### 👤 Patient Management
- Add new patients  
- List all registered patients  

### 📊 Vital Readings
- Add a vital reading for any patient  
- View all readings of a specific patient  
- **NEW:** View **latest reading summary** for all patients

### ⚕️ Intelligent Alerts
Automatic clinical alerts for:
- Tachycardia/Bradycardia  
- Hypertension/Hypotension  
- Fever/Hypothermia  
- Tachypnea/Bradypnea  

---

## 🏗 Project Architecture
PatientVitalTracker
│
├── Models/ # Domain layer (pure data classes)
│ ├── Patient.cs
│ ├── VitalReading.cs
│ ├── VitalType.cs
│ └── DataStore.cs
│
├── VitalRepository.cs # Repository Layer (File I/O, JSON storage)
│
├── App.cs # Application Layer (Console UI, business flow)
│
└── Program.cs # Entry point


### 🔍 Layer Responsibilities

| Layer | Purpose |
|-------|---------|
| **Domain (Models)** | Represents real-world entities. No business/UI logic. |
| **Repository Layer** | Handles data storage (JSON file), retrieval, and ID management. |
| **Application Layer** | Manages user interaction, menu flow, and alert logic. |

---

## 🛠️ Tech Stack

### **Languages & Runtime**
- ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
- ![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

### **Tools**
- ![VS Code](https://img.shields.io/badge/VS%20Code-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
- ![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
- ![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

---

## 📂 Data Storage

The application stores all patient and reading information in a file:

data.json

It is automatically created and updated using **System.Text.Json**.

---

## ▶️ How to Run the Project

### **1. Clone the repository**
```bash
git clone https://github.com/YOUR_USERNAME/PatientVitalTracker.git
cd PatientVitalTracker
```
### **2. Run using .NET CLI**
```bash
dotnet run
```
### **🎮 Console Menu Preview**
=== Patient Vital Tracker ===
1. Add Patient
2. List Patients
3. Add Vital Reading
4. View Patient Readings
5. View Latest Reading Summary
6. Exit

## 📸 Screenshots / Usage Demo
<img width="637" height="238" alt="image" src="https://github.com/user-attachments/assets/51fda9fb-88d4-4840-8fb4-abdbcb27c052" />
<img width="820" height="415" alt="image" src="https://github.com/user-attachments/assets/69721970-38ab-467d-9e3d-3cb0e6ea56d1" />
<img width="935" height="228" alt="image" src="https://github.com/user-attachments/assets/ec25ffd7-4282-448d-be05-27500a97e799" />

## 🚀 Future Enhancements

Here are possible upgrades that would be great for learning and interviews:

- Convert to ASP.NET Web API

- Add Unit Tests (xUnit/NUnit)

- Use Entity Framework + SQL Database

- Add Graphical UI (WinUI/WPF/Web UI)

- Add role-based login (doctor/nurse/admin)


## 👨‍💻 Author

T Pothan Sai
Beginner .NET Developer
🚀 Passionate about clean code, healthcare tech, and learning new tools.

---

# ⭐ Show Support

If you like this project or found it useful, feel free to star the repository ⭐ on GitHub!

### 👍 What You Need To Do

1. Create a file named **README.md** in your project folder (root).
2. Paste the entire content above.
3. Commit & push:

```bash
git add README.md
git commit -m "Add professional README with architecture and features"
git push
```
