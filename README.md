# Student Activity Portal

A web-based Student Activity Portal built using ASP.NET Core Razor Pages.  
This application allows users to explore activities, submit registrations, and interact with dynamic server-generated content.

## 🚀 Technologies Used

- ASP.NET Core (.NET 8)
- Razor Pages
- C#
- Bootstrap
- Logging (Microsoft.Extensions.Logging)

## 📚 Project Overview

The Student Activity Portal simulates a real-world web system where users can:

- View available activities
- Submit information via forms
- Receive dynamic server responses
- Navigate between pages
- Interact with a structured web application architecture

This project demonstrates:

- Server-side form handling
- HTTP GET and POST request processing
- Razor Page lifecycle awareness
- Layout and shared UI structure
- Logging and configuration management

---

## 🧱 Project Structure
StudentActivityPortal/
│
├── Pages/
│ ├── Index.cshtml
│ ├── Index.cshtml.cs
│ ├── Activities.cshtml
│ ├── Activities.cshtml.cs
│ ├── Shared/
│ │ └── _Layout.cshtml
│ ├── _ViewImports.cshtml
│ └── _ViewStart.cshtml
│
├── wwwroot/
│ ├── css/
│ ├── js/
│
├── appsettings.json
├── Program.cs
└── StudentActivityPortal.csproj

---

## 🔄 Application Flow

1. User visits Home page (HTTP GET)
2. Razor Page `OnGet()` executes
3. User submits form (HTTP POST)
4. `OnPost()` executes server-side
5. Dynamic message is rendered back to the browser

---

## 🧠 Lifecycle Awareness

This project demonstrates understanding of:

- HTTP request/response model
- Razor Page execution pipeline
- Server vs client rendering
- Logging during page execution

---

## ▶ Running the Project

### Option 1 – Visual Studio
Click the **Run** button.

### Option 2 – Command Line

Navigate to the project directory containing the `.csproj` file:

```bash
dotnet watch run
```

Then open the displayed localhost URL.

📌 Learning Objectives (Deliverable 1)

Create ASP.NET Core web project

Build server-rendered UI

Implement server-side event handling

Display dynamic content

Demonstrate page lifecycle understanding

Implement basic navigation

🔮 Future Enhancements

Activity registration validation

Database integration (CRUD operations)

State management

AJAX-based partial updates

Web API integration

👨‍💻 Author

Rick Smith
February 2026
Weber State University