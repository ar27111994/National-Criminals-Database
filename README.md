# National-Criminals-Database
A WCF Project explaining ASP.NET MVC and WCF best Practices using N-Layered Architecture. Here is the brief summary of every Project in the Solution Repository.

# BusinessServices:-
A WCF Class Library Project Containing All the Service Interfaces and their respective Implementations. In Addition, this Project uses Automapper to Map Database Entities to Data Transfer Objects and Vise Versa. Therefore, this project also uses **Autofac.Wcf** for **Automapper Constructor Injection** in Service Classess.

**Referenced Projects**: WebClientContracts, Persistence.

# Persistence:-
This is the Data Access Layer using **Linq to SQL** as a Micro-ORM. This is abstracted through a Generic Repository using Unit of Work Pattern for Efficient Context Memory Management.

# WebClientContracts:-
A Project for Holding Data Transfer Object Classess. Moreover, this project uses ``Microsoft.Practices.EnterpriseLibrary.Validation`` for Validation of DTOs used for WCF Service Calls. This project acts as a bridge between **BusinessServices** and **WebUIClient** Projects.

# NCDServices:-
A WCF Services Host Project. It uses **Autofac.WCF.Integration** to inject Required Parameters in Services and to Register Service Interfaces with their Respective Implementations. As this Project uses **Global.asax** to Register Autofac Container at **Application_Start** Event, Hence IIS is the best platform to Publish this project to. Moreover, each service has Different **EndPoints** for **SOAP and REST (Both JSON and XML)**. 


#WebUIClient:
An ``ASP.NET MVC 5`` Client for Consuming Web Services hosted on IIS. It also uses ``Microsoft.Practices.EnterpriseLibrary.Validation`` to handle Exceptions that can occur on Validation Fault of a DTO which is being transferred to / from WCF Services.

**Referenced Project**: WebClientContracts.

# Unit Tests:-
The Solution Contains two Separate Projects for testing **WebUIClient** and **BusinessServices** Projects Individually.

# NCD_ServicesHost:-
The Published solution of WCF Services ready for hosting.
