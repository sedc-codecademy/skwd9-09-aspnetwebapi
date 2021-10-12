export class RegisterRequestModel {
    constructor(username : string, 
                password : string, 
                confirmPassword : string, 
                firstName : string, 
                lastName : string) {
        this.Username = username
        this.Password = password
        this.ConfirmPassword = confirmPassword
        this.FirstName = firstName
        this.LastName = lastName
    }
    
    Username : string
    Password : string
    ConfirmPassword : string
    FirstName : string
    LastName : string
}