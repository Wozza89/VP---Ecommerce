# Victoria.Plumbing Endpoint Tech Test

## Project Overview

This repository is a response to a technical evaluation task, focusing on the creation of a fundamental .NET Core API endpoint. The objective of this endpoint is to receive JSON data representing a standard e-commerce order and persist it into a SQL database. The primary aim was to showcase the implementation of this functionality within a singular API endpoint while adhering to established best practices for enterprise-level development.

## Requirements

- .NET SDK Version: 7.0
- Packages:
  - Microsoft.EntityFrameworkCore: 7.0.14
  - Microsoft.EntityFrameworkCore.SqlServer: 7.0.14

## Project Structure

The project is organized as follows:

- **Victoria.Plumbing.Api:** This project contains  the API endpoint implementation.
- **Victoria.Plumbing.Core:** This project contains the core business logic, shared across the entire application.
- **Victoria.Plumbing.DataAccess:** This project contains the database context and data access logic.
- **Victoria.Plumbing.Models:** This project contains the data models utilized in the application.

## Implementation Details

### Database Design

- Incorporates Entity Framework Core for interactions with the SQL database.
- Enacts a straightforward database schema, representing orders, customers, and products.

### Business Logic

- Organizes business logic within the `OrderService` class located in the Core project.
- Applies basic validation to incoming JSON payloads.
- Illustrates how to structure and encapsulate business logic in a modular manner.

### Customer Details

- Introduces a placeholder for basic customer details in the database.
- For simplicity, only a customer name is stored in this implementation.

### Order Details

- Establishes links between customers, their orders, and the products they've ordered.
- Represents products, quantities, and costs in a clear and concise manner.

## Time Spent

Approximately 2-3 hours were allocated to the development of this solution.

## Note/To Do's

Due to time constraints, unit tests have not been incorporated into this version of the project. Additionally, the project remains untested due to limitations on the time allocated for research and implementation.
The domain models are anemic they were initially created this way with refactoring in mind in the future to change them rich domain models by bringing validation, constructors, and private setters into the domain model.
