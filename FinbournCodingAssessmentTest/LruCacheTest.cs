using FinbourneCodingAssessment;
namespace FinbournCodingAssessmentTest;

[TestFixture]
public class LruCacheTest
{
    [Test]
    public void LruCache_Get_ReturnsCorrectValue()
    {
        // Arrange
        var cache = new LruCache<int, string>(3);

        // Act
        cache.Add(1, "Apple");
        cache.Add(2, "Orange");
        cache.Add(3, "Banana");
        
        var result = cache.Get(2);

        // Assert
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void LruCache_Get_ReturnsDefaultValueForMissingKey()
    {
        // Arrange
        var cache = new LruCache<int, string>(3);

        // Act
        cache.Add(1, "Apple");
        cache.Add(2, "Orange");
        cache.Add(3, "Banana");
        var result = cache.Get(4);

        // Assert
        Assert.That(result, Is.EqualTo(default(string)));
    }
    
    [Test]
    public void LruCache_Add_RemovesLeastRecentlyUsedItemWhenCapacityReached()
    {
        // Arrange
        var cache = new LruCache<int, string>(3);

        // Act
        cache.Add(1, "Apple");
        cache.Add(2, "Orange");
        cache.Add(3, "Banana");
        cache.Add(4, "Coconut"); 
        var result = cache.Get(1);

        // Assert
        Assert.That(result, Is.EqualTo(default(string)));
    }
    
    [Test]
    public void LruCache_Add_DoesNotAddDuplicateItemKeyToCache()
    {
        // Arrange
        var cache = new LruCache<int, string>(4);

        // Act
        cache.Add(1, "Apple");
        cache.Add(2, "Orange");
        cache.Add(3, "Banana");
        cache.Add(3, "Banana");
        var result = cache.Count;

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }
    
    [Test]
    public void LRUCache_Get_UpdatesMostRecentlyUsed()
    {
        // Arrange
        var cache = new LruCache<int, string>(3);

        // Act
        cache.Add(1, "Apple");
        cache.Add(2, "Orange");
        cache.Add(3, "Banana");
        var value = cache.Get(1); 
        cache.Add(4, "Coconut");; 
        var result = cache.Get(2);

        // Assert
        Assert.That(result, Is.EqualTo(default(string)));
        Assert.That(value, Is.EqualTo("Apple"));
    }

}