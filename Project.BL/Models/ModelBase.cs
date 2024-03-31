namespace Project.BL.Model;

public abstract record ModelBase : IModel
{
    public Guid Id { get; set }
}