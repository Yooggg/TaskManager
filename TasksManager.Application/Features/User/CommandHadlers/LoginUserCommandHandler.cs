using FluentValidation;
using MediatR;
using TasksManager.Core.Command;
using TasksManager.Core.Interface;
using TasksManager.Domain.Commands.Users;
using TasksManager.Domain.Repository;

namespace TasksManager.Application.Features.User.CommandHadlers;

public class LoginUserCommandHandler : CommandHandlerBase, ICommandHandlerAsync<LoginUserCommand>, IRequestHandler<LoginUserCommand, Result>
{
    private readonly IValidator<LoginUserCommand> _loginUserCommandValidator;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IValidator<LoginUserCommand> validator, IUserRepository userRepository)
    {
        _loginUserCommandValidator = validator;
        _userRepository = userRepository;
    }
    /// <summary>
    /// Command handler contain only validation actions.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var validationResult = Validate(command, _loginUserCommandValidator);

        if (validationResult.IsValid)
        {
            Domain.Entity.User user = new()
            {
                Email = command.Email, 
                UserName = command.Email,
                Password = command.Password,
                Token = await _userRepository.GetTokenByEmailAsync(command.Email),
            };
            var errors = await _userRepository.LoginUserAsync(user);
            return errors is not null ? new Result(false, errors) : new Result(true, null);
        }

        return Return();
    }
}