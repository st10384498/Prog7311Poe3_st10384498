
# 🌱 Agri-Energy Connect

**Student:** Mihlali Nondlozi  
**Student Number:** ST10384498  
**Course:** PROG7311 – Enterprise Application Development  
**Date:** 24 June 2025  
**Repository:** [GitHub Link](https://github.com/st10384498/Prog7311Poe3_st10384498.git)

---

## 📘 Project Overview

**AgriConnect** is a web-based platform designed to empower South African farmers by connecting them with green energy experts, agricultural resources, and each other. The platform simplifies resource access, enables communication, and promotes sustainable farming practices.

This project is built using **ASP.NET Core MVC** and **C#**, with a SQL Server backend. It demonstrates key features including user registration, login, role-based dashboards, and profile management.

---

## 🚀 Features

- 🌾 **Farmer Dashboard** – Upload and manage green produce, view listings.
- 👨‍🌾 **Employee Dashboard** – Access farm reports, manage users and approvals.
- 🔐 **Authentication & Authorization** – ASP.NET Identity with role-based access.
- 📊 **Scalable SQL Backend** – Uses SSMS with stored procedures and Entity Framework.
- 📈 **Performance-Oriented** – Implements caching, pagination, optimized LINQ queries.
- 📱 **Responsive UI** – Razor views styled with Bootstrap for mobile-friendliness.
- ⚙️ **DevOps-Ready** – GitHub versioning, future CI/CD pipeline setup.

---

## 🏗️ Architecture & Tools

| Layer       | Technologies Used                                      |
|-------------|--------------------------------------------------------|
| Frontend    | ASP.NET Core MVC, Razor Views, Bootstrap               |
| Backend     | Entity Framework Core, LINQ, SQL Server Management Studio |
| Auth        | ASP.NET Identity with Role Management                  |
| DevOps      | GitHub (versioning), GitHub Actions (future-ready)     |
| Patterns    | MVC, Repository Pattern      |

## Instructions

 **Clone the Repository**
   ```bash
   git clone https://github.com/st10384498/Prog7311Poe3_st10384498.git
Database Setup

Open the provided .sql scripts in SQL Server Management Studio (SSMS).

Run the script to create the database and seed sample data.

Run the Application

Open the solution in Visual Studio.

Ensure the connection string in appsettings.json points to your local SQL instance.

Run the project using IIS Express.
   ```

**Run the App**

   * Press `F5` or click "Run" in Visual Studio

---

# Building and Running the Prototype

1. **Register a New User**

   * Choose either `Farmer` or `Employee` role during registration

2. **Log In**

   * Farmers are redirected to their dashboard to update:

     * Address
     * Contact Number
     * Profile Picture URL
   * Employees are redirected to their dashboard to update:

     * Department

3. **Log Out**

   * Click the "Logout" link in the navigation bar to end the session

---

# System Functionalities and User Roles

## User Roles and Permissions

| Role     | Functionalities                                                |
| -------- | -------------------------------------------------------------- |
| Farmer   | Register/login, set address, contact info, and profile picture |
| Employee | Register/login, set department                                 |

---

# Application Architecture

## Directory Structure

```
AgriConnectPrototype/
│
├── Models/        → User, Farmer, Employee, Product, Category
├── Views/         → Razor pages per controller (Login, Dashboard, etc.)
├── Controllers/   → UsersController, FarmerController, EmployeeController
├── Data/          → AgriConDbContext.cs (Entity Framework)
├── wwwroot/       → Static assets (CSS, images, JS)
└── appsettings.json → Connection string
```

---

# Implemented Features

* User registration and login system
* Role-based dashboard redirection
* Farmer profile setup: address, contact number, profile image path
* Employee profile setup: department
* SQL Server integration with Entity Framework Core
* Responsive UI using Bootstrap
* Header with navigation and round logo
* Placeholder views for future modules (product listings, directory)

---

# How to Build the AgriConnect Platform

This section provides step-by-step instructions to build and run the AgriConnectPrototype, an ASP.NET Core MVC web application for connecting South African farmers with green energy experts and resources.

---

## Creating the Project

1. Open **Visual Studio 2022** or later

2. Click on **"Create a new project"**

3. Select the project template:
   `ASP.NET Core Web App (Model-View-Controller)`

4. Click **Next**

5. Configure the project:

   * **Project name**: `AgriConnectPrototype`
   * **Location**: Choose your folder
   * **Solution name**: `AgriConnectSolution`
   * Click **Next**

6. Select framework:

   * **.NET 6 (Long-Term Support)** or higher
   * Set Authentication type: **None**
   * Enable HTTPS
   * Click **Create**

---

## Project Structure

After project creation, Visual Studio sets up the following structure:

```
AgriConnectPrototype/
│
├── Controllers/        → Logic for user actions (Users, Farmer, Employee)
├── Views/              → Razor pages for UI (Login, Register, Dashboards)
├── Models/             → Database entities (User, Farmer, Product, etc.)
├── Data/               → EF Core DbContext (AgriConDbContext.cs)
├── wwwroot/            → Static assets (CSS, JS, Images, Logo)
├── appsettings.json    → Configuration file (connection string)
├── Program.cs          → Application startup configuration
└── AgriConnectPrototype.csproj
```

---

## Installing Dependencies

Open **Package Manager Console** and install the required NuGet packages:

```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## Setting Up the Database Connection

1. In `appsettings.json`, configure your SQL Server connection:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AgriConnectPoePart2;Trusted_Connection=True;"
}
```

2. In `Program.cs`, configure services and middleware:

```csharp
builder.Services.AddDbContext<AgriConDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();
app.UseSession();
```

---

## Defining the Data Model

Create the following C# classes in the `Models/` folder:

* `User.cs` (stores login info and role)
* `Farmer.cs` (address, contact number, profile image)
* `Employee.cs` (department)
* `Product.cs`, `Category.cs` (for future features)

Create `AgriConDbContext.cs` in the `Data/` folder, with EF Core relationships between tables using foreign keys.

---

## Building Core Features

**UsersController**

* Manages registration, login, and logout
* Saves new users and links their profile to Farmer or Employee

**FarmerController**

* Lets farmers set/update their address, contact, and image

**EmployeeController**

* Lets employees update their department

All sessions are handled using `HttpContext.Session`.

---

## Adding Views and UI

Create corresponding Razor Views in the `Views/` folder:

* `/Views/Users/Login.cshtml`
* `/Views/Users/Register.cshtml`
* `/Views/Farmer/Dashboard.cshtml`
* `/Views/Employee/Dashboard.cshtml`

All forms are styled using Bootstrap and validate input on submission.

**Navigation Bar**:

* Added to `_Layout.cshtml` with conditional links (login/logout)
* Includes brand name and round logo on the right

**Home Page**:

* Includes a centered Bootstrap carousel
* Informative cards below carousel: What is AgriConnect, Mission, Community
* Background is dark green to reflect agriculture theme

---

## Next Steps

Once your project is running:

* Use `F5` to run the application or run using the green arrow
* Register as Farmer or Employee
* Login and access the appropriate dashboard
* Submit profile information, which is saved to the database

---


## 📹 Demonstration Video
https://youtu.be/27nWlKjzPLo?si=7Qd33f6nkn9BZlOs
