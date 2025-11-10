# Hospital Management System

A comprehensive C# console application that simulates core hospital operations including patient management, ward allocation, and search functionality using multi-dimensional arrays.

## Project Overview

This Hospital Management System is a menu-driven console application built with C# that demonstrates object-oriented programming principles and efficient data management using multi-dimensional arrays. The system manages patient admissions, bed allocation across multiple wards, discharges, and provides search capabilities.

## Features

### Core Functionality
- **Patient Admission**: Automatically assigns patients to the first available bed across multiple wards
- **Multi-Ward Management**: Uses 2D arrays to represent wards and beds efficiently
- **Patient Discharge**: Safely removes patients and frees up beds for new admissions
- **Advanced Search**: Case-insensitive patient search across all wards
- **Ward Overview**: Real-time bed occupancy status for each ward
- **Robust Error Handling**: Comprehensive exception handling for user inputs

### Technical Features
- Object-Oriented Design with separate `Patient` and `Hospital` classes
- Multi-dimensional array data structure for ward management
- Menu-driven user interface
- Input validation and error handling

## System Architecture

### Classes Structure

#### `Program`
- Main application entry point
- Handles user menu interactions
- Coordinates between different system functionalities

#### `Hospital`
Core business logic class containing:
- `Patient[,] wards` - Multi-dimensional array for ward management
- `AddPatient()` - Patient admission with automatic bed allocation
- `DischargePatient()` - Patient removal and bed deallocation
- `SearchPatient()` - Case-insensitive patient search
- `DisplayPatients()` - Complete patient listing
- `DisplayWardInformation()` - Ward occupancy statistics

#### `Patient`
Data model representing patient information:
- `Name` - Patient's full name
- `Age` - Patient's age
- `Condition` - Medical condition description

## Getting Started

### Prerequisites
- .NET SDK 5.0 or higher
- Visual Studio 2022 or VS Code with C# extension

### Installation & Running

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/hospital-management-system-csharp.git
   cd hospital-management-system-csharp
