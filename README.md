# MOM Technical Assignment
Assignment for MOM

#Design Patterns

<br />1. Repository Pattern

Why Repository Pattern ?
<br />it provides an abstraction of data, so that our application can work with a simple abstraction that has an interface approximating  that of a collection. Data processing (CURD) (for us fetch data from WebAPI) from this collection is done through a  straightforward method. Using this pattern can help achieve loose coupling and can keep domain objects persistence ignorant.

* A data persistence abstraction
* Business logic can be tested without need for an external source ( in my code WebDataService, BusinessService) 
* Database access logic can be tested separately (in my code WebDataRepository)
* No duplication of code
* Domain driven development is easier
* Centralizing the data access logic, so code maintainability is easier

<br />2. Dependency Injection Pattern

Why Dependency Injection ?
<br />Dependency Injection (DI) is an object-oriented programming design pattern that allows us to develop loosely coupled code.
<br />DI helps in getting rid of tightly coupled software components.
<br />The purpose of DI is to make code maintainable and easy to update.
<br />DI is a technique to create a dependency or dependencies outside the class that uses it. 
<br />The dependencies are injected from the code that calls the class and any information about their creation are kept away from the inside of the class
<br /> (In my code I have used constructor injection in WebDataService)

# How to build the application ?
<br />1. Download the MOM_Assignment repository
<br />2. Open in visul studio version 2017
<br />3. Build the solution in release/debug mode

# How to run the application ?
<br />1. Open command prompt
<br />2. Go to folder bin folder where .exe resides(debug or Release)  (path-> MOM_Assignment\MOM_Assignment\MOM_Assignment\bin\Release , MOM_Assignment\MOM_Assignment\MOM_Assignment\bin\Debug)
<br />3. Run exe in command line (Command -> MOM_Assignment Jan-2018 Dec-2018)
<br /> <b> Note : Run command prompt in full screen mode to view best result because of console application. 

# Others
<br /> Required Nuget Pakage Newtonsoft.Json 12.0.1
<br /> Required Nuget Pakage MarkdownLog 0.9.3
