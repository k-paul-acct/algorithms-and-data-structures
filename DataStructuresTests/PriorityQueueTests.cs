namespace DataStructuresTests;

public class PriorityQueueTests
{
    private DataStructures.PriorityQueue<string, int> _pq;

    public PriorityQueueTests()
    {
        _pq = new DataStructures.PriorityQueue<string, int>();
    }

    [Fact]
    public void EnqueueOnce()
    {
        Assert.Equal(_pq.Count, 0);

        _pq.Enqueue("q", 1);

        Assert.Equal(_pq.Count, 1);
    }

    [Fact]
    public void EnqueueMany()
    {
        _pq.Enqueue("q", 1);
        _pq.Enqueue("w", 2);
        _pq.Enqueue("e", 4);
        _pq.Enqueue("r", 6);

        Assert.Equal(_pq.Count, 4);
    }

    [Fact]
    public void EnqueueOnceAndDequeueGivesCountZero()
    {
        _pq.Enqueue("q", 1);
        _pq.Dequeue();

        Assert.Equal(_pq.Count, 0);
    }

    [Fact]
    public void EnqueueManyAndDequeueSameGivesCountZero()
    {
        _pq.Enqueue("q", 4);
        _pq.Enqueue("w", 6);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 9);
        _pq.Enqueue("t", 0);

        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();

        Assert.Equal(_pq.Count, 0);
    }

    [Fact]
    public void EnqueueWithManyItemsAndDequeueSame()
    {
        _pq = new DataStructures.PriorityQueue<string, int>(new List<(string, int)>
        {
            ("q", 5),
            ("w", 0),
            ("e", 3),
            ("r", 1),
            ("t", 6),
            ("y", 4)
        });

        Assert.Equal(_pq.Dequeue(), "w");
        Assert.Equal(_pq.Dequeue(), "r");
        Assert.Equal(_pq.Dequeue(), "e");
        Assert.Equal(_pq.Dequeue(), "y");
        Assert.Equal(_pq.Dequeue(), "q");
        Assert.Equal(_pq.Dequeue(), "t");
    }

    [Fact]
    public void EnqueueOnceAndDequeueOnce()
    {
        _pq.Enqueue("q", 1);

        Assert.Equal(_pq.Dequeue(), "q");
    }

    [Fact]
    public void DequeueMoreThanEnqueue()
    {
        _pq.Enqueue("a", 0);
        _pq.Enqueue("s", 2);
        _pq.Enqueue("d", 1);

        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();

        Assert.Throws<InvalidOperationException>(() => _pq.Dequeue());
    }

    [Fact]
    public void CreateWithInitialItems()
    {
        _pq = new DataStructures.PriorityQueue<string, int>(new List<(string, int)>
        {
            ("q", 5),
            ("w", 0),
            ("e", 3),
            ("r", 1),
            ("t", 6),
            ("y", 4)
        });

        Assert.Equal(_pq.Count, 6);

        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();

        Assert.Equal(_pq.Count, 0);
    }

    [Fact]
    public void EnqueueManyAndDequeueSame()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("w", 1);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("t", 4);
        _pq.Enqueue("y", 9);

        Assert.Equal(_pq.Dequeue(), "w");
        Assert.Equal(_pq.Dequeue(), "e");
        Assert.Equal(_pq.Dequeue(), "q");
        Assert.Equal(_pq.Dequeue(), "t");
        Assert.Equal(_pq.Dequeue(), "r");
        Assert.Equal(_pq.Dequeue(), "y");
    }

    [Fact]
    public void Clear()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("w", 1);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("t", 4);
        _pq.Enqueue("y", 9);

        _pq.Clear();

        Assert.Equal(_pq.Count, 0);

        _pq.Enqueue("a", 1);

        Assert.Equal(_pq.Count, 1);
    }

    [Fact]
    public void Peek()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("w", 1);

        Assert.Equal(_pq.Dequeue(), "w");
    }

    [Fact]
    public void PeekOnEmpty()
    {
        Assert.Throws<InvalidOperationException>(() => _pq.Dequeue());
    }
}