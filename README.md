# Project Description: Forge

"Forge" is a backend service built with ASP.NET Core that provides a RESTful API for managing events and their related packages. The project is structured using **Clean Architecture**, a design philosophy that separates the code into independent layers: Domain, Core (Application), Infrastructure, and Presentation (API). This separation makes the application highly maintainable, testable, and scalable by ensuring that the core business logic is independent of external factors like the database or UI.

The system is designed for a full DevOps lifecycle, with a Continuous Integration and Continuous Deployment (CI/CD) pipeline that automatically builds and deploys the application to **Microsoft Azure** upon every code change to the main branch.

***

## How It Works: A Request's Journey

When a client makes a request to the API, it flows through the application's layers to fetch data and return a response.

1. **API Endpoint Hit**: A request, such as `GET /Event/{guid}`, first reaches the **Presentation Layer** at the `EventController`.

2. **Business Logic Execution**: The controller delegates the task to the **Core Layer** by calling a method on the `IEventService`, for instance, `GetEventByGuid(guid)`.

3. **Data Access Request**: The `EventService` then requests the data from the **Infrastructure Layer** by calling a method on the `IEventRepository`, such as `GetAsync(e => e.Id == id)`.

4. **Database Interaction**: The `EventRepository`, which inherits from a generic `BaseRepository`, uses **Entity Framework Core** to query the database. It translates the domain-level query into a SQL query that the database can understand.

5. **Data Conversion (Entity → Domain)**: Once the data is retrieved from the database as an `EventEntity`, the `EventFactory` in the **Infrastructure Layer** converts it into a `Event` domain model. This ensures the rest of the application is not tightly coupled to the database schema.

6. **Data Conversion (Domain → DTO)**: The `Event` domain model is passed back to the `EventService` in the **Core Layer**. The service then uses the `EventDtoFactory` to convert the `Event` model into an `EventDisplay` DTO (Data Transfer Object). This DTO is a data structure specifically shaped for the API client.

7. **Response Generation**: The `EventController` receives the `EventDisplay` DTO and uses the `ApiResponseHelper` to wrap it in a standardized HTTP `IResult` (like a 200 OK status with the data as a JSON payload) before sending it back to the client.

***

## Tech Stack

Here is the technology stack used in the Forge project:

* **Backend Framework**: **ASP.NET Core**. The build workflow specifies **.NET 9.x**.
* **Database ORM**: **Entity Framework Core** is used to map C# objects to the database schema and handle data operations.
* **Database**: **Azure SQL Database**, as indicated by the `UseAzureSql` configuration.
* **Cloud Platform & Hosting**:
  * **Azure App Service** is the target for deployment, as defined in the GitHub Actions workflow.
  * **Azure Key Vault** is used for secure management of application secrets like connection strings.
* **API Documentation**:
  * **Swagger (OpenAPI)** for generating interactive API documentation and a UI.
  * **Scalar** for an alternative, clean API reference view.
* **DevOps**: **GitHub Actions** for automating the CI/CD pipeline (build, test, and deploy).
* **Architecture**: **Clean Architecture** (also known as Onion Architecture).
* **Dependency Injection**: The framework's built-in DI container is used extensively to manage dependencies between layers.
