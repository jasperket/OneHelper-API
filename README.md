# OneHelper - Scheduler and Sleep Tracker

## Problem Statement

Many individuals struggle with effective time management and maintaining healthy sleep patterns. Traditional scheduling tools often lack integration with sleep tracking, making it difficult to optimize productivity while ensuring adequate rest. OneHelper addresses this gap by providing a unified platform that helps users manage their daily tasks while monitoring and improving their sleep quality.

## Target Users

- **Busy Professionals** who need to balance work tasks with healthy sleep schedules
- **Students** managing coursework, assignments, and study sessions while maintaining good sleep hygiene
- **Health-conscious individuals** who want to track their sleep patterns alongside their daily productivity
- **Anyone** seeking better time management and sleep optimization through data-driven insights

## Top Features

- **📋 Task Management**: Create prioritized to-do lists with time tracking and progress monitoring
- **😴 Sleep Tracking**: Log sleep patterns with duration, quality notes, and optimization suggestions
- **📊 Analytics Dashboard**: View comprehensive statistics and visualizations for productivity and sleep trends
- **🔐 User Management**: Secure authentication with personal profiles and data persistence

## How to Run

### Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or Visual Studio Code

### Backend Setup (ASP.NET Core API)

1. **Clone the repository**

   ```bash
   git clone [repository-url]
   cd OneHelper
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

3. **Update database connection string**

   - Open `appsettings.json`
   - Modify the `DefaultConnection` string if needed:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OneHelperDb;Trusted_Connection=True;MultipleActiveResultSets=true;"
   }
   ```

4. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

5. **Run the application**

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5143` (HTTP) or `https://localhost:7015` (HTTPS)

6. **Access API documentation**
   - Navigate to `http://localhost:5143/swagger` to view the Swagger UI
   - Use the API endpoints to interact with the application

## Development Team

- Jan Christian D. Estudillo
- Christian Paul S. Matuguina
- Jasper Keith O. Vallecera
- Kenneth A. Sumaylo

---

_OneHelper - Your personal assistant for better time management and sleep optimization._
