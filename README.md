# Cinema-System - Blaze Cinema

# Summary
A group project delveloped for a Team Project module in 3rd year, 2023.

The team size was 3 people that were new to Blazor and MudBlazor.

# Requirments
- .NET 6.0
- SQL Server Express

# NuGet Packages
- Blazor 
- MudBlazor
- Identity
- EF Core
- FluentValidation
- FluentEmail.Smtp

# Set up
To set up the database, you must ensure that you have the default project selected as Cinema.DataAccess inside the package manager console. 
If you don't do this the commands will not work for migrations.

![image](https://user-images.githubusercontent.com/61046303/235925152-ce391776-0f7f-46ac-a430-048b9e487c99.png)

Once the database is created, run the SQL script called "RUN-ALL.sql". This will populate the database with data to get a working 
version of the website.

![image](https://user-images.githubusercontent.com/61046303/235926367-5eedd464-a0bf-4dbc-a422-c6a656e6d33c.png)

Once the database is populated, run the Cinema.Server.

![image](https://user-images.githubusercontent.com/61046303/235926687-d2b9d73b-6cdf-4919-b948-ec6a8f1e1c3d.png)


