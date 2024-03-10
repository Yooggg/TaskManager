using MediatR;

namespace TasksManager.Core.Interface;

public interface ICommand<T> : IRequest<T>
{
    
}