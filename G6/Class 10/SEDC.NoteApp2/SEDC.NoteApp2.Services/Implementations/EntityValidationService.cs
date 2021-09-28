using SEDC.NoteApp2.DataAccess.Interfaces;
using SEDC.NoteApp2.Domain.Models;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Dto.ValidationModels;
using SEDC.NoteApp2.Mappers;
using SEDC.NoteApp2.Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SEDC.NoteApp2.Services.Implementations
{
    public class EntityValidationService : IEntityValidationService
    {
        private IUserRepository _userRepository;

        public EntityValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ValidationResponse ValidateNote(NoteDto noteDto)
        {
            User user = _userRepository.GetById(noteDto.UserId);

            if (user == null)
            {
                return ValidationResponse.CreateErrorValidation($"The user with id {noteDto.UserId} was not found");
            }

            if (string.IsNullOrEmpty(noteDto.Text))
            {
                return ValidationResponse.CreateErrorValidation("The property Text for note is required");
            }

            if (noteDto.Text.Length > 100)
            {
                return ValidationResponse.CreateErrorValidation("The property Text can not contain more than 100 caracters");
            }

            return ValidationResponse.CreateSuccessValidation();
        }

        public ValidationResponse ValidateUser(UserDto userDto)
        {
            User user = userDto.ToUser();
            ValidationContext validationContext = new ValidationContext(user);
            List<ValidationResult> results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, validationContext, results, true))
            {
                return ValidationResponse.CreateErrorValidation(results.FirstOrDefault().ErrorMessage); // this is example
            }

            if (_userRepository.IsUsernameInUse(userDto.Username))
            {
                return ValidationResponse.CreateErrorValidation($"Username: {userDto.Username} is not available.");
            }

            return ValidationResponse.CreateSuccessValidation();
        }
    }
}
