namespace Project.DAL.Entities;
    public class StudentEntity : IEntity
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public string? Photo { get; set; }
    }
