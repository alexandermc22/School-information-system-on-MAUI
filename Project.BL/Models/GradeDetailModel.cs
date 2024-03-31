namespace Project.BL.Model;

public class GradeDetailModel: ModelBase
{
    public required Guid GradeId { get; set }
    public required Guid SubjectId { get; set }
    public required string SubjectCode { get; set }
    public required Guid ActivityId { get; set }
    public required Grade GradeValue { get; set }
    public required DateTime GradeDate { get; set; }
    public static GradeDetailModel Empty => new()
    {
        id = Guid.NewGuid(),
        GradeId = Guid.Empty,
        SubjectId = Guid.Empty,
        SubjectCode = string.Empty,
        ActivityId = Guid.Empty,
        GradeValue = GradeScore.F,
        GradeDate = DateTime.MinValue
    }
  
    
}