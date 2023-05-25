# Contact Management

It is necessary to change the connection string for the desired server.
To do so, access the appsettings.json file and modify the value for the MariaDB key within the ConnectionStrings group.

It is also necessary to use migrations to create the database.
To do so, it is able to use an already created migration: 
- open the Package Manager Console;
- execute the command 'Update-Database';

OR create a new migration:
- open the Package Manager Console;
- create a new migration using the command 'Add-Migration "migration-name"' ;
- execute the command 'Update-Database'.
