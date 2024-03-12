using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksManager.Application.Features.Tasks.Interfaces;
using TasksManager.Core.Command;
using TasksManager.Domain.Commands.Tasks;

namespace TasksManager.Controllers.Task;

[Route("api/v1/task/")]
[ApiController]
public class TaskController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<TaskController> _logger;
    private readonly ITasksQueries _tasksQueries;

    public TaskController(IMediator mediator, ITasksQueries tasksQueries, ILogger<TaskController> logger)
    {
        _mediator = mediator;
        _tasksQueries = tasksQueries;
        _logger = logger;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(200, Type = typeof(Result))]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.Succes)
        {
            _logger.LogInformation("New task added");
            return Ok(command);
        }
        
        _logger.LogInformation("Error when trying to add new task");
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("fetch")]
    [ProducesResponseType(200, Type = typeof(Result))]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [AllowAnonymous]
    public IActionResult FetchTask([FromQuery] long id)
    {
        return Ok(_tasksQueries.GetTaskByIdAsync(id));
    }
}