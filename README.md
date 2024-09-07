# Ticket Management System

## Overview
The Ticket Management System is a .NET 8 application designed to handle the creation, management, and automatic processing of tickets. It implements CQRS (Command Query Responsibility Segregation) pattern using MediatR and follows Domain-Driven Design principles.

## Features
- Create tickets with properties: Id, creation date and time, phone number, governorate, city, and district
- List tickets with pagination
- Handle tickets manually
- Automatic handling of tickets after 60 minutes
- Color-coding of tickets based on creation time

## Technology Stack
- .NET 8
- Entity Framework Core with SQLite
- MediatR for CQRS implementation
- xUnit for unit and integration testing

## Project Structure
- TicketManagementSystem.Domain: Contains the core domain models and logic
- TicketManagementSystem.Application: Contains application logic, CQRS commands, queries, and handlers
- TicketManagementSystem.Infrastructure: Contains data access layer implementations alongside with background services
- TicketManagementSystem.Api: The API layer that handles HTTP requests
- TicketManagementSystem.UnitTests: Contains unit tests

## Setup and Installation

1. Clone the repository:
   ```
   git clone https://github.com/mahmoud1brahim/TicketManagementSystem.git
   ```

2. Navigate to the project directory:
   ```
   cd TicketManagementSystem
   ```

3. Restore NuGet packages:
   ```
   dotnet restore
   ```

4. Navigate to the Infrastructure project:
   ```
   cd TicketManagementSystem.Infrastructure
   ```

5. Run database migrations: (you might not need to do this step because I have included db files)
   ```
   dotnet ef migrations add InitialCreate --startup-project ../TicketManagementSystem.Api
   dotnet ef database update --startup-project ../TicketManagementSystem.Api
   ```

6. Navigate back to the main directory and run the API:
   ```
   cd ..
   dotnet run --project TicketManagementSystem.Api
   ```

The API should now be running on `https://localhost:5148` (the exact port may vary).

## Usage

### Creating a Ticket
Send a POST request to `/api/tickets` with the following JSON body:
```json
{
  "phoneNumber": "1234567890",
  "governorate": "Example Governorate",
  "city": "Example City",
  "district": "Example District"
}
```

### Listing Tickets
Send a GET request to `/api/tickets?page=1&pageSize=10`

### Handling a Ticket
Send a PUT request to `/api/tickets/{id}/handle`

## Running Tests
To run unit tests:
```
dotnet test TicketManagementSystem.UnitTests
```

