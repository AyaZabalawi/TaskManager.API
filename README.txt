Requirement:
Build a web API using clean architecture in .NET Core
Use Entity Framework Core with code-first approach for the database
Implement Insert, Delete, Update, and Get CRUD operations.

Solution: Task Management API
Task Management API that allows users to create, read, update, and delete tasks. 
Each task has properties like title, description, due date, and status (e.g., pending, completed).

	Task entity: Id, Title, Description, DueDate, Status

	Endpoints:
	GET /api/tasks – Retrieve a list of all tasks
	GET /api/tasks/{id} – Retrieve a specific task by ID
	POST /api/tasks – Create a new task
	PUT /api/tasks/{id} – Update an existing task
	DELETE /api/tasks/{id} – Delete a task