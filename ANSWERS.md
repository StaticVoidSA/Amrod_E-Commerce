## Architecture & Integration Reasoning

### Chosen Technology Stack

- **Framework**: ASP.NET Core MVC with Razor Views  
- **Language**: C# 8.0 (with nullable reference types enabled)  
- **Authentication**: ASP.NET Core Identity  
- **Database**: Microsoft SQL Server (remotely hosted)  
- **ORM**: Entity Framework Core  
- **Testing**: xUnit + EF Core In-Memory Database  

### High-Level Architecture

The application follows a **layered architecture** to ensure clear separation of concerns, improved testability, and long-term maintainability:

- **Presentation Layer** (`Controllers`, `Views`, `ViewModels`)  
  Razor Views handle the UI, Controllers manage requests and responses, and ViewModels are used to shape data specifically for the views (preventing direct exposure of database entities).

- **Service Layer** (`Services`)  
  Contains all business logic (`ProductService`, `CartService`, etc.). Services keep controllers thin and make the core logic reusable and easy to unit test.

- **Data Access Layer** (`Data/Context`, `Data/Entities`)  
  `AppDbContext` (which inherits from `IdentityDbContext`) manages database operations and Identity integration. Entities represent the database tables.

- **Test Layer** (`Amrod_E-Commerce.Tests`)  
  Unit tests focused on the service layer using xUnit and an in-memory database for fast, isolated testing.

### Database Integration

- Remote Microsoft SQL Server is used as the production database.
- Connection strings are managed via `appsettings.json` (with overrides in `appsettings.Development.json`).
- All database operations are performed **asynchronously** to handle network latency effectively.
- Entity Framework Core is used for migrations, querying, and change tracking.

**Key considerations for remote SQL:**
- Proper use of `Include()` / `ThenInclude()` for eager loading when needed.
- Asynchronous patterns (`ToListAsync()`, `SaveChangesAsync()`, etc.) throughout the codebase.
- Potential for connection resiliency (retry logic) in production.

### Identity Integration

ASP.NET Core Identity is fully integrated for user management:
- Supports registration, login, password hashing. Profile managementhas not been implemented but can be easily added.
- Uses the same `AppDbContext` (via `IdentityDbContext`) so user data lives alongside e-commerce entities.
- Account pages were scaffolded while keeping the rest of the application in classic MVC style.

### Testing Strategy

Unit tests are written with **xUnit** and focus primarily on the service layer (`ProductService` and `CartService`).  
An EF Core **In-Memory Database** is used for fast, isolated tests. Each test creates a unique database instance using `Guid.NewGuid()` to prevent test interference.

### Future-Proofing

The current architecture is a clean **monolith** that can naturally evolve into:
- Vertical Slice Architecture (feature-based folders)
- API + SPA separation (if a mobile or React frontend is added later)
- Full Clean Architecture with Domain-Driven Design

### Eager Loading & Performance
- Performance and scalability considerations already applied include proper paging, async database access, and selective eager loading.
- Pagination, filtering and sorting are implemented in `GetProductsPaged` to prevent loading large datasets into memory.


## Data Accuracy & System Stability

### How We Ensure Data Accuracy and System Stability (General Approach)

In a production e-commerce application with a remote SQL Server database, maintaining **data accuracy** (integrity, consistency, and correctness) and **system stability** (reliability under load, error handling, and resilience) is critical.

**Key strategies include:**

- **Input Validation & Business Rules** — Validate data at multiple layers (ViewModels, services, and database constraints) to prevent invalid data from entering the system.
- **Transactional Integrity** — Use database transactions or EF Core’s change tracking to ensure atomic operations (e.g., adding to cart or updating stock).
- **Exception Handling & Logging** — Graceful error handling with detailed logging to avoid silent failures or data corruption.
- **Async Database Operations** — All I/O-bound work is asynchronous to prevent thread blocking and improve scalability with remote databases.
- **Query Optimization** — Use `AsNoTracking()` for read-only queries, proper `Include()`/`ThenInclude()`, paging, and database indexing to reduce load and prevent performance degradation.
- **Testing** — Comprehensive unit tests with in-memory databases + future integration tests against real SQL Server.
- **EF Core Best Practices** — Parameterized queries (built-in with EF), no client-side evaluation where possible, and proper DbContext lifetime management.

These practices minimize data corruption, race conditions, and downtime — especially important when the database is hosted remotely.
