using FluentValidation;
using MediatR;
using TasksManager.Core.Command;
using TasksManager.Core.Interface;
using TasksManager.Domain.Commands.Users;
using TasksManager.Domain.Repository;

namespace TasksManager.Application.Features.User.CommandHadlers;

public class CreateUserCommandHandler : CommandHandlerBase, ICommandHandlerAsync<CreateUserCommand>, IRequestHandler<CreateUserCommand, Result>
{
    private readonly IValidator<CreateUserCommand> _createUserCommandValidator;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IValidator<CreateUserCommand> createUserCommandValidator, IUserRepository userRepository)
    {
        _createUserCommandValidator = createUserCommandValidator;
        _userRepository = userRepository;
    }
    
    public async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validationResult = Validate(command, _createUserCommandValidator);

        if (validationResult.IsValid)
        {
            Domain.Entity.User user = new()
            {
                Email = command.Email, 
                UserName = command.Email,
                Password = command.Password
            };
            await _userRepository.AddAsync(user);
        }

        return Return();
    }
}