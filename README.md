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

