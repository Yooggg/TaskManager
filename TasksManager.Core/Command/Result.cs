namespace TasksManager.Core.Command;

public class Result
{
    private readonly bool _success;
    private readonly IEnumerable<string> _errors;

    public Result(bool success, IEnumerable<string> errors)
    {
        _success = success;
        _errors = errors;
    }
}