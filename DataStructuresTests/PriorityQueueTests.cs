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
        Assert.That(_pq.Count, Is.EqualTo(0)); 
        
        _pq.Enqueue("q", 1);
        
        Assert.That(_pq.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void EnqueueMany()
    {
        _pq.Enqueue("q", 1);
        _pq.Enqueue("w", 2);
        _pq.Enqueue("e", 4);
        _pq.Enqueue("r", 6);
        
        Assert.That(_pq.Count, Is.EqualTo(4));
    }

    [Test]
    public void EnqueueOnceAndDequeueGivesCountZero()
    {
        _pq.Enqueue("q", 1);
        _pq.Dequeue();
        
        Assert.That(_pq.Count, Is.EqualTo(0));
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

        Assert.That(_pq.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void EnqueueOnceAndDequeueOnce()
    {
        _pq.Enqueue("q", 1);
        
        Assert.That(_pq.Dequeue(), Is.EqualTo("q"));
    }
    
    [Test]
    public void EnqueueManyAndDequeue()
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
}