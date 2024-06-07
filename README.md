# School Information System Documentation
## Overview
The goal of this project is to develop a usable and easily extensible school information system. The application should be robust, user-friendly, and must persist data reliably.

## Table of Contents
- Introduction
- Project Architecture
- Functionality
- Technologies Used
- Usage
- Development Process

The School Information System is designed to manage data related to students, subjects, and activities. The application ensures persistent storage of data using SQLite and provides a user-friendly interface for CRUD operations. It also supports filtering and searching functionalities.

## Project Architecture
The project follows a layered architecture to ensure logical separation of concerns. It consists of the following layers:

- Presentation Layer (App): Contains the MAUI front-end for the application.
- Business Logic Layer (BL): Contains business logic, including ViewModels and Services.
- Data Access Layer (DAL): Manages data access using Entity Framework Core.
Solution Structure
- App: Contains the front-end code (Views and ViewModels).
- BL: Contains business logic, services, and DTOs.
- DAL: Contains entity classes, DbContext, and repositories.
## Functionality
### Core Features
- CRUD Operations: Create, Read, Update, Delete operations for Students, Activities, Subjects, and Grades.
- Filtering: Users can filter activities by start and end dates within a selected subject.
- Searching: Users can search for subjects and students.
- Sorting: Users can sort lists by various fields (name, points, subject abbreviation, etc.).
- Persistence: Data is saved immediately after user operations to ensure no data is lost on application restart.
- Concurrent Updates: Multiple instances of the application can run simultaneously, with changes in one instance reflected in others after data reload.
## Technologies Used
- .NET MAUI: For building the cross-platform user interface.
- Entity Framework Core: For ORM and database management.
- SQLite: For local data storage.
- xUnit: For unit and integration testing.
- Azure DevOps: For source code management, CI/CD, and project tracking.

## Usage
- Adding a Student
- Navigate to the Students section.
- Click on "Add Student".
- Fill in the required fields (FirstName, LastName, Photo URL).
- Save the student.
- Adding an Activity
- Navigate to the Activities section.
- Click on "Add Activity".
- Fill in the required fields (Subject, Start, End, Room, Type/Tag, Description).
- Assign students to the activity.
- Save the activity.
- Filtering Activities
- Navigate to the Activities section.
- Use the filter options to set the start and end dates.
- Apply the filter to view the relevant activities.
- Searching
- Use the search bar in the Students or Subjects section to find specific entries.

## Development Process
- Phase 1: Object Design and Database
Designed entity classes and relationships.
Created DbContext and DbSet properties.
Generated ER diagram and wireframes.
Implemented Entity Framework Core with Code First approach.

- Phase 2: Repositories and Mapping
Implemented repository pattern for data access.
Created DTOs and mapping logic.
Developed unit and integration tests to verify repository functionality.
Set up CI/CD pipelines in Azure DevOps.

- Phase 3: MAUI Frontend and Data Binding
Developed ViewModels and connected them to DTOs.
Implemented data binding in XAML.
Created user-friendly views for CRUD operations and data display.
Conducted thorough testing to ensure application stability and correctness.
