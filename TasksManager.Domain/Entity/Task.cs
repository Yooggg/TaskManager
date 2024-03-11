using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksManager.Core.Entity;

namespace TasksManager.Domain.Entity;
[Table("task")]
public class Task : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("taskid")]
    public long TaskId { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("details")]
    public string Details { get; set; }
    
    [Column("id")]
    public string Id { get; set; }

    public Task(string title, string details)
    {
        Title = title;
        Details = details;
    }

    public Task()
    {
    }
}