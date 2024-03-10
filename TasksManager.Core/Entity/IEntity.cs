﻿namespace TasksManager.Core.Entity;

public interface IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}