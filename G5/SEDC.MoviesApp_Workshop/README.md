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
* title
* description
* year
* genre (enum)

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

* Keep data in a fixed static class for now

* Add SWAGGER

**Bonus** 
* Get all user's movies rented by same genre
* Implement CORS
