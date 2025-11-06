# Event Booking Management System (EBS)

A full-stack Event Booking Management System with a React frontend and an ASP.NET Core (.NET 8) backend. The frontend provides public event browsing and role-based flows (Attendee, Organizer, Admin). The backend exposes REST endpoints for events, users, and RSVPs and uses Entity Framework Core for data access.

## Tech stack
- Frontend: React, React Router, Tailwind CSS, lucide-react (icons)
  - Source: event-frontend/
- Backend: ASP.NET Core (.NET 8), Entity Framework Core
  - Controllers: EventController, UsersController, RsvpController
  - Models: Event, User, RSVP
  - Data: EventContext (DbContext)
  - Project files: Program.cs, appsettings.json, Controllers/, Models/, Data/
- Development: Visual Studio 2022 (supports .NET 8), Node.js (for frontend)

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 (workload: ASP.NET and web development) or use dotnet CLI
- Node.js (>= 16 recommended) and npm (or yarn/pnpm)
- A database server referenced in __appsettings.json__ (SQL Server, SQLite, etc.) — update connection string as needed

## Quick start

1. Backend
   - Open the solution in Visual Studio 2022 or use the terminal.
   - Update the database connection string in __appsettings.json__ to match your environment.
   - From the backend project folder (the folder containing Program.cs) run:
     - Restore & build:
       dotnet restore
       dotnet build
     - Apply EF Core migrations (if migrations are present) or create them:
       - Ensure dotnet-ef is available: dotnet tool install --global dotnet-ef
       - To add a migration (if none exist): dotnet ef migrations add InitialCreate
       - To update DB: dotnet ef database update
     - Run:
       dotnet run
   - Or in Visual Studio set the backend project as startup and use __Debug > Start Debugging__ (or press __F5__).

2. Frontend- view repository "event booking organization system frontend"
   - Open a terminal in event-frontend/
   - Install:
     npm install
   - Configure API base URL:
     - Edit __event-frontend/src/App.js__ (or a dedicated config) to point to the backend URL (e.g., http://localhost:5000 or the address shown when running the backend).
   - Start:
     npm start
   - The frontend will typically run at http://localhost:3000

3. Run both
   - Start the backend first, then the frontend. Ensure CORS is enabled in the backend (if required) so the frontend can call the API.

## Important files & folders
- event-frontend/src/ — React app
  - pages/: HomePage.jsx, EventList.jsx, DetailsPage.jsx, DashboardPage.jsx
  - components/: Header.jsx, LoginForm.jsx, UserForm.jsx, EventForm.jsx, EventRSVPForm.jsx
  - App.js — main app routing and API base usage (update here if needed)
- Controllers/ — API controllers (EventController.cs, UsersController.cs, RsvpController.cs)
- Models/ — Event.cs, User.cs, RSVP.cs
- Data/EventContext.cs — EF Core DbContext
- Program.cs — app host and middleware configuration
- appsettings.json — connection strings, app settings

## API (common endpoints)
The backend controllers provide standard REST endpoints. Example routes (adjust base path if configured differently):
- GET /api/events
- GET /api/events/{id}
- POST /api/events
- PUT /api/events/{id}
- DELETE /api/events/{id}
- POST /api/users/register
- POST /api/users/login
- GET /api/rsvps
- POST /api/rsvps

Open the controllers in Controllers/ to see exact routes and request/response shapes.

## Development notes
- If you change models, add and apply EF Core migrations.
- Update the frontend API base URL when backend port or host changes.
- Use Postman or curl to test API endpoints while developing.
- To debug backend in Visual Studio, set breakpoints and use __Debug > Start Debugging__.
- To run frontend in a browser with hot reload, use __npm start__ from event-frontend/.

## Troubleshooting
- "Connection refused" — verify backend is running and connection string in __appsettings.json__ is correct.
- CORS errors — enable CORS in Program.cs (ConfigureServices / Configure) or allow the frontend origin.
- Migrations errors — ensure EF Core tools are installed and the migration history is consistent.

## Contributing
- Follow the existing code style.
- Add migrations when changing data models.
- Run the app locally and add tests for new functionality where appropriate.

## License
MIT (or choose a license for your project)

---

This README.md was added to the repository root to describe setup, structure, and run instructions for the Event Booking Management System (EBS).
