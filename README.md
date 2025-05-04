# PersonalFinanceTracker

## Table of Contents
1. [Setup Instructions]
2. [Technology Choices and Reasoning]
3. [Architecture]
4. [Assumptions]
5. [Additional Features]

## Setup Instructions

### Prerequisites
- Install [Visual Studio Code](https://code.visualstudio.com/) or any IDE of your choice.
- Install [dotnet](https://dotnet.microsoft.com/download) (for .NET applications).
- Install [SQLite](https://www.sqlite.org/download.html) (if using SQLite as the database).

### Installation
1.Clone this repository:
   	git clone https://github.com/KnightRider1234/PersonalFinanceTracker.git

2.Set up the backend:
	cd Server
	dotnet restore
	dotnet build

3.Set up the frontend:
	cd Client
	dotnet restore
	dotnet build

4.Set up the database (SQLite is used in this project):
	dotnet ef database update

5.Run the project:
	dotnet run

## Technology Choices and Reasoning

### Frontend
 Blazor WebAssembly is used to build the frontend UI. It enables a modern, component-based approach, and since it's part of the .NET ecosystem, it allows code sharing between client and server.

### Backend
 ASP.NET Core Web API is chosen to handle REST API requests, providing an effective and scalable architecture for handling CRUD operations and client-server communication.

### Database
 SQLite was selected for its simplicity and easy setup. It’s ideal for small-to-medium applications like this personal finance tracker. However, SQL Server can also be used for production.

## Architecture

#### Frontend (Blazor WebAssembly)

Built using Blazor WebAssembly to create a reactive UI in C#.

Components such as MudSelect, MudNumericField, and MudDatePicker from the MudBlazor library are used for the UI.

Features include form validation, entry management (add, edit, delete), and displaying financial summaries.

#### Backend (ASP.NET Core Web API)

Handles HTTP requests from the frontend.

Implements the CRUD operations for the finance entries using a RESTful API.

Uses Entity Framework Core to interact with the database.

#### Database (SQLite)

Stores data about income, expenses, and savings.

Entity Framework Core handles the database migrations and CRUD operations.

### Folder Structure

#### Frontend (Blazor)

Pages: Contains UI components (e.g., Add Entry, Dashboard).

Services: API communication layer that interacts with the backend.

Models: Contains data models like EntryDto.

#### Backend (ASP.NET Core)

Controllers: API controllers to handle HTTP requests.

Models: Contains Entity Framework Core models for database interaction.

## Assumptions
Authentication: The app assumes no user authentication as it is designed for a single-user scenario.

Database: SQLite is used for local development, but the app can be migrated to SQL Server for production use.

Input Validation: Input validation is assumed to be minimal. Additional checks, such as ensuring entries are not in the future, have been included.

## Additional Features

Pagination/Filtering: To improve the performance and usability of the dashboard, client side pagination and filtering implemented.

Responsive Design: The UI can be enhanced to be more responsive, supporting mobile and tablet views effectively.

Error Handling: Basic error handling is implemented in the API, but additional work can be done to ensure better error reporting and handling in production environments.

## Time Estimation vs. Actual Time Spent

| Task                              | Estimated Time | Actual Time     |
|-----------------------------------|----------------|------------------|
| Project Setup & Architecture      | 30 mins        | 1 hr          	|
| Backend API Implementation        | 40 mins        | 1 hr 45 mins     |
| Blazor Frontend Implementation    | 50 mins        | 2 hrs            |
| UI Styling with MudBlazor         | 20 mins        | 1 hr        	|
| Form Validation                   | 20 mins        | 30 mins          |
| README & Documentation            | 20 mins        | 20 mins          |

**Total**                           | **2.5 hours**  | **6.5 hours**
