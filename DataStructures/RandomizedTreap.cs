namespace DataStructures;

public class RandomizedTreap<TKey>
{
    private readonly Random _random;
    private readonly Treap<TKey, double> _treap;

    public RandomizedTreap()
    {
        _treap = new Treap<TKey, double>();
        _random = new Random();
    }

    public int Height()
    {
        return _treap.Height();
    }

    public TKey Top()
    {
        return _treap.Top();
    }

    public TKey Peek()
    {
        return _treap.Peek();
    }

    public void Insert(TKey key)
    {
        _treap.Insert(key, _random.NextDouble());
    }

    public bool Remove(TKey key)
    {
        return _treap.Remove(key);
    }

    public bool Contains(TKey key)
    {
        return _treap.Contains(key);
    }

    public TKey Min()
    {
        return _treap.Min();
    }

    public TKey Max()
    {
        return _treap.Max();
    }
}