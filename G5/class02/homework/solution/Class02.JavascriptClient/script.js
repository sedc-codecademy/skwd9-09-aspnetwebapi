// DOM elements
let firstNameInput = document.getElementById("firstName");
let lastNameInput = document.getElementById("lastName");
let ageInput = document.getElementById("age");
let createUserButton = document.getElementById("createUserBtn");

createUserButton.addEventListener("click", function() {

    let user = {
        FirstName : firstNameInput.value,
        LastName : lastNameInput.value,
        Age : ageInput.value
    }

    var options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }

    fetch('https://localhost:5001/api/users/createuser', options)
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(err => {
        console.log("error has occured!!!")
        console.warn(err)
    })

})



