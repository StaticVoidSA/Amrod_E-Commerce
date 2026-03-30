## Getting Started - Running the Project Locally

This guide will help you set up and run **Amrod_E-Commerce** on your local machine.

The application uses a **remotely hosted SQL Server** by default, but you can easily switch to a local database if needed. All EF Core migrations are included in the project.

### 1. Prerequisites

- **.NET 8 SDK** (required)
- **SQL Server** (either the remote one you already have, or a local instance / Docker)
- **Visual Studio 2022** (recommended) or VS Code + C# Dev Kit
- Git

### 2. Clone the Repository

```bash
git clone https://github.com/yourusername/Amrod_E-Commerce.git
cd Amrod_E-Commerce
```


### 3. Run migrations (When migrating to a new databse)
- cd Amrod_E-Commerce
- dotnet ef database update

### 4. Run the unit tests
- Right click on the project and select "Run Tests" in Visual Studio, or use the command line:
- Open your terminal and run dotnet run tests
```bash


