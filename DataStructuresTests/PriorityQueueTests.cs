namespace DataStructuresTests;

public class PriorityQueueTests
{
    private DataStructures.PriorityQueue<string, int> _pq = null!;

    [SetUp]
    public void Setup()
    {
        _pq = new DataStructures.PriorityQueue<string, int>();
    }

    [Test]
    public void EnqueueOnce()
    {
        Assert.That(_pq, Is.Empty);

        _pq.Enqueue("q", 1);

        Assert.That(_pq, Has.Count.EqualTo(1));
    }

    [Test]
    public void EnqueueMany()
    {
        _pq.Enqueue("q", 1);
        _pq.Enqueue("w", 2);
        _pq.Enqueue("e", 4);
        _pq.Enqueue("r", 6);

        Assert.That(_pq, Has.Count.EqualTo(4));
    }

    [Test]
    public void EnqueueOnceAndDequeueGivesCountZero()
    {
        _pq.Enqueue("q", 1);
        _pq.Dequeue();

        Assert.That(_pq, Is.Empty);
    }

    [Test]
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

        Assert.That(_pq, Is.Empty);
    }

    [Test]
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

        Assert.That(_pq.Dequeue(), Is.EqualTo("w"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("r"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("e"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("y"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("q"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("t"));
    }

    [Test]
    public void EnqueueOnceAndDequeueOnce()
    {
        _pq.Enqueue("q", 1);

        Assert.That(_pq.Dequeue(), Is.EqualTo("q"));
    }

    [Test]
    public void DequeueMoreThanEnqueue()
    {
        _pq.Enqueue("a", 0);
        _pq.Enqueue("s", 2);
        _pq.Enqueue("d", 1);

        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();

        Assert.That(() => _pq.Dequeue(), Throws.InvalidOperationException);
    }

    [Test]
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

        Assert.That(_pq, Has.Count.EqualTo(6));

        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();
        _pq.Dequeue();

        Assert.That(_pq, Is.Empty);
    }

    [Test]
    public void EnqueueManyAndDequeueSame()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("w", 1);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("t", 4);
        _pq.Enqueue("y", 9);

        Assert.That(_pq.Dequeue(), Is.EqualTo("w"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("e"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("q"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("t"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("r"));
        Assert.That(_pq.Dequeue(), Is.EqualTo("y"));
    }

    [Test]
    public void Clear()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("w", 1);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("t", 4);
        _pq.Enqueue("y", 9);

        _pq.Clear();

        Assert.That(_pq, Is.Empty);

        _pq.Enqueue("a", 1);

        Assert.That(_pq, Has.Count.EqualTo(1));
    }

    [Test]
    public void Peek()
    {
        _pq.Enqueue("q", 3);
        _pq.Enqueue("e", 2);
        _pq.Enqueue("r", 6);
        _pq.Enqueue("w", 1);

        Assert.That(() => _pq.Dequeue(), Is.EqualTo("w"));
    }

    [Test]
    public void PeekOnEmpty()
    {
        Assert.That(() => _pq.Dequeue(), Throws.InvalidOperationException);
    }
}