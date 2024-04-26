namespace Project.DAL.Entities;
    public record StudentEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Uri? Photo { get; set; }
        
        public ICollection<StudentSubjectEntity> StudentSubject  { get; set; } = new List<StudentSubjectEntity>();
    }
