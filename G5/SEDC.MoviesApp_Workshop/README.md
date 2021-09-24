# Exercise 
## Part 1
Create an API that keeps and manages your favorite movies. It should have the option to:

* create new movie
* get movie by id
* get all movies 
* get movie by genre
* delete movie
* update movie

A movie contains:
* Id
* Title
* Description
* Year
* Genre (enum)

A genre contains:
* Action
* Comedy
* Thriller
* Drama
* SciFi
* Adventure

Introduce a new entity into the web api implementation for Users. There should be a User handling endpoints for:
* Create new user
* Get all users
* Get user by id
* Get all user's movies rented

A user contains:
* Id
* Username
* Password
* First Name
* Last Name
* Favorite Genre
* MoviesList
* Subscription (enum)

A Subscription contains:
* Default
* Premium

Other:
* Keep data in a fixed static class for now
* Add SWAGGER

* Add the solution to new github repository

**Bonus** 
* Get all user's movies rented by same genre
* Implement CORS and small vanilla js app that pings only one get endpoint to prove that the CORS works

## Part 2
Implement entity framework in the solution and switch the database from CashDb to Entity Framework.

* Make relationship between User and Movie. The relationship should be one to many

**Hints**
- Create new repositories that will inherit from the generic one. 
- Implement all the methods from the interface with the entity framework implementation. (use the dbcontext class instead of the CashDb) 
- Switch the implementation of the interfaces in the startap class from CashDb to the newly created entity framework repositories.
