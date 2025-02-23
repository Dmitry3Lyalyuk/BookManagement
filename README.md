BookManagement offers a service for managing a comprehensive digital library. This service provides functionalities for adding, updating, and deleting books, as well as retrieving a ranked list of the most popular titles. Built using the principles of clean architecture, BookManagement boasts high scalability. Furthermore, it leverages technologies such as MS SQL Server, Swagger API for documentation, FluentValidation for data validation, and MediatR for mediating commands and queries. 
JWT authentication was implemented. All functions, except for delete, were made publicly accessible for ease of use. Two of these functions require a valid authorization token to execute requests. You can achieve this using Postman by providing a Bearer token in the request headers.
