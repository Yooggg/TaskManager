namespace TasksManager.Core.Command;

public class Result
{
    public readonly bool Succes;
    public readonly IEnumerable<string> Errors;

    public Result(bool success, IEnumerable<string> errors)
    {
        Succes = success;
        Errors = errors;
    }
}