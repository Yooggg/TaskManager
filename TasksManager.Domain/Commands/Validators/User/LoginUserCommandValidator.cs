using FluentValidation;
using TasksManager.Domain.Commands.Users;
using TasksManager.Domain.Commands.Validators.Base;
using TasksManager.Domain.Repository;

namespace TasksManager.Domain.Commands.Validators.User;

public class LoginUserCommandValidator : UserCommandValidatorBase<LoginUserCommand>
{
    private readonly IUserRepository _userRepository;
    
    public LoginUserCommandValidator(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
        ValidateEmail();
        ValidatePassword();
    }
    
    private void ValidatePassword()
    {
        RuleFor(userCommand => userCommand.Password).NotEmpty().WithMessage("Please enter the password");
    }
    
    private void ValidateEmail()
    {
        RuleFor(userCommandBase => userCommandBase.Email)
            .MustAsync(async (name, cancellationToken) => (await _userRepository.ExistsAsync(name)))
            .WithSeverity(Severity.Error)
            .WithMessage("User with this email not found.");
    }
}