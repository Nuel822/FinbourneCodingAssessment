namespace FinbourneCodingAssessment;

public class LruCache<TKey, TValue> where TKey : notnull
{
    private readonly int Capacity;
    private readonly Dictionary<TKey, LinkedListNode<Item>> ItemMap;
    private readonly LinkedList<Item> LruItemList;
    public int Count;

    public LruCache(int capacity)
    {
        if (capacity <= 0)
        {
            Console.WriteLine("Capacity: " + capacity);
            throw new ArgumentException("Capacity must be greater than zero ${capacity}");
        }

        Capacity = capacity;
        ItemMap = new Dictionary<TKey, LinkedListNode<Item>>(capacity);
        LruItemList = new LinkedList<Item>();
        Count = LruItemList.Count;

    }

    public TValue? Get(TKey key)
    {
        if (ItemMap.TryGetValue(key, out var node))
        {
            LruItemList.Remove(node); // remove the item from the list to add it to the front of the list.
            LruItemList.AddFirst(node);

            return node.Value.Value;
        }

        return default(TValue);
    }

    public void Add(TKey key, TValue value)
    {
        // Check and remove the least used item from cache
        if (ItemMap.Count >= Capacity)
        {
            var leastUsedItem = LruItemList.Last;
            
            if (leastUsedItem != null) 
                ItemMap.Remove(leastUsedItem.Value.Key);
            LruItemList.RemoveLast();
        }

        if (String.IsNullOrEmpty(Get(key)?.ToString()))
        {
            var newItem = new LinkedListNode<Item>(new Item(key, value));
            LruItemList.AddFirst(newItem);
            ItemMap[key] = newItem;
        }

        Count = LruItemList.Count;
    }
    
    private class Item
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public Item(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}