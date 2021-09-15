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

