# Manual for Employees App Service

This project was created for a tech interview request.

The service was created using .Net 8. Here you can see the use of controllers, REST APIs, LINQ, Entity Framework, migrations and SQL Server.

## Setting up Database

Create an empty DB on the last version of SQL Server. Tables will be automatically created by the service migrations when service runs.

## Setting up Service

Follow this instructions to run the service:

1. Ensure to have the last version of VS installed and have .Net 8.

2. Go to the `appsettings.json` file and change EmployeeConnection for your DB connection string.

## Run the Service

Change the build to HTTP and then Run the app using the Run button. Please ensure the service is running in http://localhost:5163/swagger/index.html.

## Important Notes

This service is just the BE for the Employees UI. Please follow the README on the employee-ui folder.
