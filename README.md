### Description

This is a small VB.NET WebForms repro project, created for the purpose of reproducing the database
connection error discussed in detail at [StackOverflow](https://stackoverflow.com/q/71907148).

The problem is that the application cannot connect to its supporting database. Failures occur,
however, only when attempting to connect under these conditions:

1. EntityFramework 6 DbContext
2. Running under an Azure App Service
3. Connecting to an Azure SQL instance

Other scenarios produce successful connections:

1. [ADO.NET] [local website] [local database]
2. [ADO.NET] [Azure App Service] [Azure SQL]
3. [EntityFramework] [local website] [local database]

### Error

The stack trace for the `System.Data.SqlClient.SqlException` indicates Named Pipes as
the protocol under which the application attempts to connect. Various reports indicate that
`System.Data.SqlClient` falls back to Named Pipes after a failed TCP connection, assuming the
TCP protocol is specified in the connection string. In this case, both TCP and NP are failing;
neither attempt is logged by the Azure SQL Server.

### Setup

To prepare for running this application, perform these steps:

1. Create a new Azure Web App
2. Download and import the WebDeploy publish settings into the project (you may wish to remove the current profile)
3. Ensure the profile's configuration is set to `Release`
4. Using the Azure Portal (not SSMS), create a new empty Azure SQL database named `DbConnectionTest`
5. Copy the connection string to the clipboard for Step 4 below

To run this application, perform these steps:

1. Show all files in the project
2. Edit `Db\Utils.vb` to provide the datasource and credentials for the design-time connection string (the login must have `DbCreator` permissions)
3. Edit `Web.config` to provide the connection string for the local database
4. Edit `Web.release.config` to provide the connection string for the Azure SQL database

### Repro

1. In Visual Studio, press F5 to run the application
2. Note that the TextArea control displays the name "Fred Flintstone"
3. Using the publish profile you created earlier, publish the application to Azure
4. Browse to the newly created website
5. Note that the TextArea control displays:
    a. The connection string that was used for the connection attempt
    b. A report indicating that the ADO.NET connection was successful
    c. The EntityFramework connection error stack trace
