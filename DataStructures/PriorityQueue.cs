using System.Runtime.CompilerServices;

namespace DataStructures;

public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    private readonly IComparer<TPriority> _comparer;
    private (TElement Element, TPriority Priority)[] _nodes;

    public PriorityQueue()
    {
        _nodes = Array.Empty<(TElement, TPriority)>();
        _comparer = Comparer<TPriority>.Default;
    }

    public PriorityQueue(int initialCapacity)
    {
        _nodes = initialCapacity >= 0
            ? new (TElement, TPriority)[initialCapacity]
            : throw new ArgumentOutOfRangeException(nameof(initialCapacity));
        _comparer = Comparer<TPriority>.Default;
    }

    public PriorityQueue(IEnumerable<(TElement, TPriority)> items)
    {
        _nodes = items != null ? items.ToArray() : throw new ArgumentNullException(nameof(items));
        Count = _nodes.Length;
        _comparer = Comparer<TPriority>.Default;
        if (Count > 1) Heapify();
    }

    public int Count { get; private set; }

    private void MoveUp(int index)
    {
        var current = _nodes[index];
        while (index > 0)
        {
            var parentIndex = GetParentIndex(index);
            if (_comparer.Compare(current.Priority, _nodes[parentIndex].Priority) < 0)
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

    private void MoveDown(int index)
    {
        var current = _nodes[index];
        while (index < GetFirstLeafIndex())
        {
            var childIndex = index * 2 + 2 < Count
                ? _comparer.Compare(_nodes[index * 2 + 1].Priority, _nodes[index * 2 + 2].Priority) < 0
                    ? index * 2 + 1
                    : index * 2 + 2
                : index * 2 + 1;
            if (_comparer.Compare(_nodes[childIndex].Priority, current.Priority) < 0)
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

    private void Heapify()
    {
        for (var i = (Count - 1) >> 1; i >= 0; i--) MoveDown(i);
    }

    private static int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) >> 1;
    }

    private int GetFirstLeafIndex()
    {
        return ((Count - 2) >> 1) + 1;
    }

    public TElement Peek()
    {
        if (Count == 0) throw new InvalidOperationException();
        return _nodes[0].Element;
    }

    private void ExpandArray()
    {
        var newSize = (long)_nodes.Length * 2;
        if (newSize > Array.MaxLength) newSize = Array.MaxLength;
        if (_nodes.Length + 4 > newSize) newSize = _nodes.Length + 4;
        Array.Resize(ref _nodes, (int)newSize);
    }

    public void Enqueue(TElement element, TPriority priority)
    {
        var nodeIndex = Count++;
        if (nodeIndex == _nodes.Length) ExpandArray();
        _nodes[nodeIndex] = (element, priority);
        MoveUp(nodeIndex);
    }

    public TElement Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException();
        var top = _nodes[0].Element;
        if (--Count > 0)
        {
            _nodes[0] = _nodes[Count];
            MoveDown(0);
        }

        if (RuntimeHelpers.IsReferenceOrContainsReferences<(TElement, TPriority)>())
            _nodes[Count] = default;
        return top;
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
                MoveDown(index);
                break;
            case < 0:
                MoveUp(index);
                break;
        }

        return true;
    }

    public void Clear()
    {
        Count = 0;
        if (RuntimeHelpers.IsReferenceOrContainsReferences<(TElement, TPriority)>())
            Array.Clear(_nodes, 0, Count);
    }
}