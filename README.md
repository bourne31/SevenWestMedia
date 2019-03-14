# SevenWestMedia Technical Assignment

This repository contains my solution for the SevenWestMedia technical assignment. I designed the project in such a way that it meets the following criteria:

### Structure of the application

I patterned the structure of the application to Clean Architecture as designed by Uncle Bob. The pillar of this architecture is the dependency inversion principle.

#### Domain
This project contains the business entities or models.

#### Infrastructure
This project represents the data source, repositories, providers (API, file system, In Memory etc.). 

#### Core
This project represents the use cases or the business actions. It contains pure business logic, plain code.

#### ConsoleApp
This represents the presentation layer. This can be replaced with API, Web or Windows app.

#### Tests
This project contains the unit tests.


### Testability
Since the pillar of the project architecture is dependency inversion, it means that the solution is highly testable. I have added unit tests in the solution and all use cases are covered just to make sure.

### Readability
I made sure that the project is easy to read, follow and understand by using naming methods and variables appropriately.

### Reusability
The core of the project is reusable since the use cases do not know who triggered it and how are the results going to be displayed. Hence, it can be reused to different presentation layer.

### Performance
Since the number of user records may change in the file, it is very important to make sure that performance is not affected. So for the parsing of the Json file, it is recommended to read the
json from stream as the json size doesn't matter because only a small part is read at a time from either file or from the HTTP request.
 
## How to run

1. Clone the repo
2. Open SevenWestMedia.Technical.sln in Visual Studio 2017
3. Right click on the solution project
4. Restore Nuget Packages
3. Build
4. Run [F5]







