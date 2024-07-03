# OrderService
```
OrderService
├── Controllers
│   └── OrdersController.cs
├── Models
│   └── Order.cs
│   └── OrderContext.cs
├── Services
│   └── OrderService.cs
├── Requests
│   └── OrderRequest.cs
├── Program.cs
├── appsettings.json
└── Properties
    └── launchSettings.json

```

Overview
The OrderService allows users to:

-Create new orders (InventoryWorker)
-Update orders (Manager)
-Delete orders (Manager)
-Retrieve all orders (Manager)
-Retrieve a specific order by ID (Manager)

Core Concepts
-Order: Represents a wheel with various attributes like year, make, model, damage type, notes, etc.
-Roles: We have two roles: Manager and InventoryWorker. Managers can perform all operations, while InventoryWorkers can only add orders.

Components
-Order.cs: The model representing an order.
-OrderContext.cs: The Entity Framework context for accessing the database.
-OrderService.cs: The service containing business logic for managing orders.
-OrdersController.cs: The API controller handling HTTP requests related to orders.
-OrderRequest.cs: The DTO (Data Transfer Object) for creating and updating orders.
