Future Workshops Task Management App A simple full-stack application built using Angular and .NET Core to manage tasks with features like creation, editing, deletion, and status tracking.

# Future Workshops Task Management

A full-stack task management application developed as part of the Future Workshops technical task. This project includes a .NET Core Web API backend and an Angular frontend.

## 🔧 Technologies Used

### Backend
- .NET Core Web API (Restful)
- Entity Framework Core
- SQL Server

### Frontend
- Typescript
- Angular 15+
- Bootstrap 5
- Angular Material

## ✨ Features

- ✅ Create, edit, and delete tasks
- 📅 Assign due dates to tasks
- 🔄 Change task status (Not Started, In Progress, Completed)
- 🔍 View tasks by Pagination
- 💬 Modal dialogs for create/edit/delete

## 📁 Project Structure

FutureWorkshopsTask/
├── Backend/ # .NET Core API
│ └── WebAPI/
│ └── Business/
│ └── Infrastructure/
│ └── Domain/
│ └── Domain
├── Frontend/ # Angular App
│ └── src/app/
│ └── components/
│ └── services/
│ └── models/
│ └── pages


## 🚀 Getting Started

### Prerequisites

- Node.js
- Angular CLI
- .NET SDK
- SQL Server

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone (https://github.com/Rehab-Ashraf/future-workshops-task.git)
cd Backend
dotnet restore
dotnet ef database update
dotnet run
cd ../Frontend
npm install
npm start
Visit http://localhost:4200 in your browser.

📌 Notes
Task statuses are managed using an ETaskStatus enum.

Modals are used for all CRUD operations to ensure a smooth UI experience.

Error handling and validation are included for better UX.

