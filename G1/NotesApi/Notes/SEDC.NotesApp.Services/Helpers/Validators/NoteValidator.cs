using FluentValidation;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Services.Helpers.Validators
{
    public class NoteValidator : AbstractValidator<NoteModel>
    {
        public NoteValidator()
        {
            RuleFor(note => note.Text).NotEmpty().WithMessage("Note text is empty")
                                      .MinimumLength(2).WithMessage("Note text must be bigger than 2 characters");
        }
    }
}
