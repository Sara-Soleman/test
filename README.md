# test
this is the test 
Database Design:

Products table: Id (PK), Name_AR, Name_EN, CreationDate, StartDate, Duration, Price
CustomFields table: Id (PK), ProductId (FK), Title_AR, Title_EN
CustomFieldValues table: Id (PK), CustomFieldId (FK), Key_AR, Key_EN, Value_AR, Value_EN
Categories table: Id (PK), Name_AR, Name_EN
ProductCategories table: ProductId (FK), CategoryId (FK)
API Endpoints:

GET /api/products?lang={language}
Returns a list of products that are supposed to show up at the current time in the specified language.
GET /api/products/{id}?lang={language}
Returns a product by its id in the specified language.
POST /api/products
Creates a new product with custom fields and adds it to the database.
PUT /api/products/{id}
Updates an existing product with custom fields in the database.
DELETE /api/products/{id}
Deletes a product and its associated custom fields from the database.
Security:

Implement user authentication and authorization using JWT (JSON Web Tokens)(NOT APPLIED WRIGHT NOW BUT IN FUTURE).
Use HTTPS to encrypt all requests and responses between the client and the server.
Error Handling:

Return appropriate HTTP status codes and error messages for different scenarios such as invalid input, resource not found, server errors, etc.

Postman Collection:

Create a Postman collection that includes all the API endpoints with sample requests and responses for testing and documentation purposes.
