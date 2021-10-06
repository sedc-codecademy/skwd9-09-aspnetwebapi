# Workshop 
## Part 1
We need to create an API that keeps and manages our favorite movies. It should have the option to:
* keep data in a fixed static class
* create new movie
* update a movie
* delete a movie
* get movie by id
* get all movies 
* filter movies by genre and/or year

A movie contains:
* id
* title - required field
* description
* year - required field
* genre - required field

### Bonus
Add model for Director. Each director can have multiple directed movies. Each movie is directed by one director.
We keep the following information about a director:
* id
* firstName
* lastName
* country

Add option to filter the movies by directors country. For example, we have: Movie1 - director with country MK, Movie2 - director with country USA,
Movie3 director with country MK. If we filter by MK, we should get the first and the last movie.


* Configure Swagger


# Part 2

* Create N tier architecture for the application
* Create appropriate dtos for getting data from client and returning it
* Create custom exceptions 
* Impelement dependency injection
* Connect the application to database, use EF
* Create appropriate db context and implement the repository pattern
* Movie title should contain maximum 100 characters, description maximum 250 characters
* For the ones who implemented directors, all the fields are required with maximum length of 100 characters
* Read the connection string from the appSettings.json

** Bonus for the ones who implemented directors, add the method for filtering according country as a repository method

# Part 3
Our next step is to implement JWT authentication in our app.
* Configure the application to use JWT token authentication
* Implement managing users because of this purpose ( User entities and the necessary architecture)
* Impelement user registration and login
* Each user can have a role. The possible roles are: SuperAdmin, Admin and User
* Add claims for id, role and username to the token
* Only a logged in user can get all the movies and a movie by id.
* Only admins can create and update movies.
* Only a user with username superadmin can delete a movie
* The method for filtering by genre and/or year can be accessed by anyone, the user doesn't have to be logged in.

### Bonus 
Impelement movie reservation. 
* Each movie can be reserved by multiple users, each user can reserve multiple movies.
* Upgrade the GetAll method to return only the movies reserved by the logged in user, using the id from the token's claim.


