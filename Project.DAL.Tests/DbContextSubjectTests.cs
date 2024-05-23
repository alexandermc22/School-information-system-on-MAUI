/*
using Project.Common.Tests.Seeds;


using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Project.DAL.Tests;

/// <summary>
/// Tests shows an example of DbContext usage when querying strong entity with no navigation properties.
/// Entity has no relations, holds no foreign keys.
/// </summary>
public class DbContextSubjectTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task GetAll_StudentSubjects_ForSubject()
    {
        //Act
        var studentSubjects = await ProjectDbContextSUT.StudentSubjects
            .Where(i => i.SubjectId == SubjectSeeds.Math.Id)
            .ToArrayAsync();

        //Assert
        Assert.Contains(StudentSubjectSeeds.Student1Math with { Student = null!, Subject = null!}, studentSubjects);
        Assert.Contains(StudentSubjectSeeds.Student2English with { Student = null!, Subject = null!}, studentSubjects);
    }

    /*[Fact]
    public async Task GetAll_Ingredients_ContainsSeededWater()
    {
        //Act
        var entities = await CookBookDbContextSUT.Ingredients.ToArrayAsync();

        //Assert
        Assert.Contains(IngredientSeeds.Water, entities);
    }

    [Fact]
    public async Task GetById_Ingredient_WaterRetrieved()
    {
        //Act
        var entity = await CookBookDbContextSUT.Ingredients.SingleAsync(i=>i.Id == IngredientSeeds.Water.Id);

        //Assert
        Assert.Equal(IngredientSeeds.Water, entity);
    }

    [Fact]
    public async Task Update_Ingredient_Persisted()
    {
        //Arrange
        var baseEntity = IngredientSeeds.WaterUpdate;
        var entity =
            baseEntity with
            {
                Name = baseEntity + "Updated",
                Description = baseEntity + "Updated",
            };

        //Act
        CookBookDbContextSUT.Ingredients.Update(entity);
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Ingredients.SingleAsync(i => i.Id == entity.Id);
        Assert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_Ingredient_WaterDeleted()
    {
        //Arrange
        var entityBase = IngredientSeeds.WaterDelete;

        //Act
        CookBookDbContextSUT.Ingredients.Remove(entityBase);
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        Assert.False(await CookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == entityBase.Id));
    }

    [Fact]
    public async Task DeleteById_Ingredient_WaterDeleted()
    {
        //Arrange
        var entityBase = IngredientSeeds.WaterDelete;

        //Act
        CookBookDbContextSUT.Remove(
            CookBookDbContextSUT.Ingredients.Single(i => i.Id == entityBase.Id));
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        Assert.False(await CookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == entityBase.Id));
    }

    [Fact]
    public async Task Delete_IngredientUsedInRecipe_Throws()
    {
        //Arrange
        var entityBase = IngredientSeeds.IngredientEntity1;

        //Act & Assert
        CookBookDbContextSUT.Ingredients.Remove(entityBase);
        await Assert.ThrowsAsync<DbUpdateException>(async () => await CookBookDbContextSUT.SaveChangesAsync());
    }#1#
}
*/
