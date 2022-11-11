namespace DataStructures;

public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    private readonly IComparer<TPriority> _comparer = Comparer<TPriority>.Default;
    private (TElement Element, TPriority Priority)[] _nodes;

    public PriorityQueue()
    {
        _nodes = Array.Empty<(TElement, TPriority)>();
    }

    public PriorityQueue(IEnumerable<(TElement, TPriority)> items)
    {
        _nodes = items != null ? items.ToArray() : throw new ArgumentNullException(nameof(items));
        Count = _nodes.Length;
        Heapify();
    }

    public int Count { get; private set; }

    private void Heapify()
    {
        for (var i = (Count - 1) / 2; i >= 0; i--) PushDown(i);
    }

    private void PullUp(int index)
    {
        var current = _nodes[index];
        while (index > 0)
        {
            var parentIndex = GetParentIndex(index);
            if (_comparer.Compare(_nodes[parentIndex].Priority, current.Priority) > 0)
            {
                _nodes[index] = _nodes[parentIndex];
                index = parentIndex;
            }
            else
            {
                break;
            }
        }

        _nodes[index] = current;
    }

    private static int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) >> 2;
    }

    private int GetFirstLeafIndex()
    {
        return ((Count - 2) >> 2) + 1;
    }

    private void PushDown(int index)
    {
        var current = _nodes[index];
        while (index < GetFirstLeafIndex())
        {
            var (child, childIndex) = HighestPriorityChild(index);
            if (_comparer.Compare(child.Priority, current.Priority) < 0)
            {
                _nodes[index] = _nodes[childIndex];
                index = childIndex;
            }
            else
            {
                break;
            }
        }

        _nodes[index] = current;
    }

    public TElement Peek()
    {
        if (Count == 0) throw new InvalidOperationException();
        return _nodes[0].Element;
    }

    private void ExpandArray()
    {
        var newSize = (int)Math.Min((long)_nodes.Length * 2, Array.MaxLength);
        newSize = Math.Max(newSize, _nodes.Length + 4);
        Array.Resize(ref _nodes, newSize);
    }

    private ((TElement Child, TPriority Priority), int Index) HighestPriorityChild(int index)
    {
        return _comparer.Compare(_nodes[index * 2 + 1].Priority, _nodes[index * 2 + 2].Priority) < 0
            ? (_nodes[index * 2 + 1], index * 2 + 1)
            : (_nodes[index * 2 + 2], index * 2 + 2);
    }

    public void Enqueue(TElement element, TPriority priority)
    {
        var nodeIndex = Count++;
        if (nodeIndex == _nodes.Length) ExpandArray();
        _nodes[nodeIndex] = (element, priority);
        PullUp(nodeIndex);
    }

    public TElement Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException();
        var p = _nodes[--Count];
        // _nodes[Count] = default; TODO: fix
        if (Count == 0) return p.Element;
        var element = _nodes[0].Element;
        _nodes[0] = p;
        PushDown(0);
        return element;
    }

    public bool ChangePriority(TElement element, TPriority newPriority)
    {
        if (element == null) throw new ArgumentNullException(nameof(element));
        if (newPriority == null) throw new ArgumentNullException(nameof(newPriority));
        var index = -1;
        for (var i = 0; i < Count; i++)
        {
            if (!element.Equals(_nodes[i].Element)) continue;
            index = i;
            break;
        }

        if (index == -1) return false;
        var oldPriority = _nodes[index].Priority;
        _nodes[index].Priority = newPriority;
        switch (_comparer.Compare(newPriority, oldPriority))
        {
            case > 0:
                PushDown(index);
                break;
            case < 0:
                PullUp(index);
                break;
        }

        return true;
    }
}