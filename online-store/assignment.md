# Task 01: Database Transactions in an Online Store

You will implement a transactional order processing feature in a .NET application using Entity Framework Core (EF Core) following Clean Architecture principles. The application simulates an online store where placing an order affects inventory, orders, and payment records within a single transaction.

## Objectives

- Apply Clean Architecture principles clearly separating application logic, domain models, and infrastructure.
- Implement transactional logic using EF Core.
- Ensure data consistency and handle transaction failures correctly.
- Demonstrate understanding of transaction scopes, rollbacks, and commit strategies.
- Practice writing testable, maintainable, and well-structured code.

## Application Structure

Follow Clean Architecture principles:

- **Domain Layer**: Entities, domain logic.
- **Application Layer**: Use cases (services), interfaces.
- **Infrastructure Layer**: EF Core data context, repositories.
- **Presentation Layer (Optional)**: REST API

## Tasks

### 1. Setup Domain Entities

Define domain entities clearly:

- `Product`
- `Order`
- `Payment`

### 2. Define Interfaces

Create repository interfaces in the Application Layer, such as:

- `IOrderRepository`
- `IProductRepository`
- `IPaymentRepository`
- `IUnitOfWork`

### 3. Implement Infrastructure

- EF Core `DbContext` setup.
- Repositories implementing the interfaces.
- Implement UnitOfWork pattern for transaction handling.

### 4. Implement Application Logic

Implement a service (`OrderService`) that:

- Checks product inventory.
- Creates an order.
- Updates product inventory.
- Records a payment.

All these actions should execute within a single transaction using EF Core.

### 5. Implement Application Logic: Product Inventory Service

Implement a service (`ProductInventoryService`) that:

- Checks the current inventory count for a given product.
- Updates the inventory count for a given product.

## Isolation Levels

Explore the various isolation levels and how you should choose the right one for the task.