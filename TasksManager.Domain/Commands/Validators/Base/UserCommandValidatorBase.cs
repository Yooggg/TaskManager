using FluentValidation;
using TasksManager.Domain.Commands.Base;
using TasksManager.Domain.Repository;

namespace TasksManager.Domain.Commands.Validators.Base;

public class UserCommandValidatorBase<T> : AbstractValidator<T> where T : UserCommandBase
{
    private readonly IUserRepository _userRepository;

    public UserCommandValidatorBase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        ValidateEmail();
    }
    
    private void ValidateEmail()
    {
        RuleFor(userCommandBase => userCommandBase.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
    }
}