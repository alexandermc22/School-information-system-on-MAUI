using Project.BL.Facades;
using Project.BL.Models;
using Project.Common.Enum;
using Project.Common.Tests;
using Project.Common.Tests.Seeds;
using System.Collections.ObjectModel;
using Xunit;
using Xunit.Abstractions;

namespace Project.BL.Tests;

public class SubjectFacadeTests : FacadeTestsBase
{
    private readonly ISubjectFacade _subjectFacadeSUT;

    public SubjectFacadeTests(ITestOutputHelper output) : base(output)
    {
        _subjectFacadeSUT = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new SubjectDetailModel()
        {
            Id = Guid.Empty,
            Name = "History",
            Code = "IHS",
        };

        var _ = await _subjectFacadeSUT.SaveAsync(model);
        
        
    }
}