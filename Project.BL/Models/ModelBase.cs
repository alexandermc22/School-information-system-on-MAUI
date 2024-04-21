namespace Project.BL.Models;

public abstract record ModelBase : IModel
{
    public Guid Id { get; set; }
}