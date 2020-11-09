 <img align="left" width="116" height="116" src="https://raw.githubusercontent.com/jasontaylordev/CleanArchitecture/master/.github/icon.png" />
 
 # Ace Ace Group Test Application

<br/>
<br/>

This is a test application developed for Ace Ace Group using Clean Architecture. Following are the requirements
* Create OneSignal Account (it’s free). You have to use OneSignal Rest API to perform CRUD operation using .NET Framework MVC, Entity framework code first approach
* You have to implement only Apps API e.g. View all Aps, Create App, Update App.
* There will be 2 roles Admin and Data Entry Operator.
* Admin can perform all crud operations while Data Entry Operator role can only view all apps. Use MVC identity for user management. 
* There’s no need to spend a lot of time on UI, you can use Razor.
* Architecture of application should be clean and easy to understand. Follow Solid Pattern.
* Once you done this assignment upload code at GitHub and share the link with Readme file where you can define steps to run the application. 

## Technologies

* ASP .NET Core 3.1
* Entity Framework Core 3.1
* MS SQL Server 2016


## Getting Started

* Download this git repository to your local computer
* Navigate to the folder path
* Open **AceAceTestApp/AceAceTestApp.sln** in Visual Studio 2019
* Wait for the packages to be restored automatically
* Build the application


### Database Configuration

Modify the **DefaultConnection** connection string within **appsettings.json** in **AceAceTestApp.UI.MVC>>AceAceTestApp.MVC** to a valid SQL Server instance.

```json
   "ConnectionStrings": {
    "DefaultConnection": "Server=Your_SQL_Instance_Name;Database=AceAceTestApp;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
```

### Set Startup Project

In Visual studio solution explorer, right click on **AceAceTestApp.MVC** under **AceAceTestApp.UI.MVC** and click **Set as Startup Project**


<img src="https://user-images.githubusercontent.com/27881417/98599490-72020900-22f5-11eb-95fe-bbdcb9e9a358.png">


### Database Migrations

Code first approach is used for development of this application. Initial Migrations are already created.

In Visual Studio Menu, Open **Tools>>NuGet Packet Manager>>Package Manager Console**

In the Package Manager Console, enter the command **Update-Database** to create database with necessary tables

```json
   PM> Update-Database
```


<img src="https://user-images.githubusercontent.com/27881417/98601330-52b8ab00-22f8-11eb-84e8-337f963de078.png">


An admin & data entry user have been seeded in the migration

### Run Application

Press F5 in Visual Studio to run the application.

As per the requirement, there is 2 users created. An admin & a data entry user.

* Admin User
```json
   Email: admin@test.com
   Password: P@ssw0rd
```
* Data Entry User 
```json
   Email: dataentry@test.com
   Password: P@ssw0rd
```

### Page Screenshots

* View Page

<img src="https://user-images.githubusercontent.com/27881417/98599614-b7263b00-22f5-11eb-88aa-d5bd2803ce0d.png">

* Add Page

<img src="https://user-images.githubusercontent.com/27881417/98599803-02d8e480-22f6-11eb-8637-db38a8385a92.png">

* Data Entry if try to add/edit

<img src="https://user-images.githubusercontent.com/27881417/98599853-18e6a500-22f6-11eb-880b-0b77b9f02ce7.png">



## Overview

### Architecture

Clean architecture is used for the development of this application with repository design pattern

### Domain

This will contain all entities, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. All of our services, interfaces and ViewModels will go here

### Infrastructure.Data

This layer contains classes for accessing external resources such as database, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer. Dbcontext will be added in this layer

### Infrastructure.IoC

This layer contains dependency container class. This connects our interfaces and their implementations from multiple projects into single point of reference.

### UI.MVC

This layer is the user application. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.
