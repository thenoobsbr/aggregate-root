using FluentAssertions;

namespace TheNoobs.AggregateRoot.UnitTests;

[Trait("Category", "UnitTests")]
[Trait("Class", "Entity")]
public class IdTests
{
    [Fact(DisplayName = @"GIVEN an Id, WHEN compare with same SHOULD be equals")]
    public void Given_id_when_compare_with_same_should_be_equals()
    {
        var id1 = new Id<long>(1);
        id1.Equals(id1).Should().BeTrue();
    }
    
    [Fact(DisplayName = @"GIVEN an Id, WHEN compare different with same value SHOULD be equals")]
    public void Given_id_when_compare_with_same_value_should_be_equals()
    {
        var id1 = new Id<long>(1);
        var id2 = new Id<long>(1);

        id1.Equals(id2).Should().BeTrue();
    }
    
    [Fact(DisplayName = @"GIVEN an Id, WHEN compare same inner value SHOULD be equals")]
    public void Given_id_when_compare_with_same_inner_value_should_be_equals()
    {
        var id1 = new Id<long>(1);
        long id2 = 1;

        id1.Equals(id2).Should().BeTrue();
    }
    
    [Fact(DisplayName = @"GIVEN an Id, WHEN compare with same value but different type SHOULD be different")]
    public void Given_id_when_compare_same_value_different_type_should_be_different()
    {
        var id1 = new Id<long>(1);
        int id2 = 1;

        id1.Equals(id2).Should().BeFalse();
    }
    
    [Fact(DisplayName = @"GIVEN an Id, WHEN compare with same value but different type SHOULD be different")]
    public void Given_id_when_compare_null_value_should_be_different()
    {
        var id1 = new Id<long>(1);

        id1.Equals(null).Should().BeFalse();
    }
}
