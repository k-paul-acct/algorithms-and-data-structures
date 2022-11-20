namespace DataStructures;

public class Treap<TKey, TPriority>
{
    private readonly Comparer<TKey> _keyComparer;
    private readonly Comparer<TPriority> _priorityComparer;

    public Treap()
    {
        _keyComparer = Comparer<TKey>.Default;
        _priorityComparer = Comparer<TPriority>.Default;
    }

    public Treap(BinaryTreeNode<TKey, TPriority> root) : this()
    {
        Root = root;
    }

    public BinaryTreeNode<TKey, TPriority>? Root { get; set; }

    public int Height()
    {
        return CommonOperations.Height(Root);
    }

    public TKey Top()
    {
        if (Root == null) throw new InvalidOperationException();
        var key = Root.Key;
        Remove(key);
        return key;
    }

    public TKey Peek()
    {
        return Root != null ? Root.Key : throw new InvalidOperationException();
    }

    public void Insert(TKey key, TPriority priority)
    {
        var newNode = new BinaryTreeNode<TKey, TPriority>(key, priority);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        var node = Root;
        var parent = node;

        while (node != null)
        {
            parent = node;
            node = _keyComparer.Compare(key, node.Key) <= 0 ? node.Left : node.Right;
        }

        if (_keyComparer.Compare(key, parent.Key) <= 0) parent.Left = newNode;
        else parent.Right = newNode;

        newNode.Parent = parent;

        while (newNode.Parent != null && _priorityComparer.Compare(newNode.Value, newNode.Parent.Value) < 0)
        {
            var res = newNode == newNode.Parent.Left ? newNode.RotateRight() : newNode.RotateLeft();
            if (res) Root = newNode;
        }
    }

    public bool Remove(TKey key)
    {
        var node = Root.Find(key);
        if (node == null) return false;
        if (node.IsRoot() && node.IsLeaf())
        {
            Root = null;
            return true;
        }

        if (!node.IsLeaf())
        {
            bool res;
            if (node.Left != null &&
                (node.Right == null || _priorityComparer.Compare(node.Left.Value, node.Right.Value) < 0))
                res = node.Left.RotateRight();
            else
                res = node.Right!.RotateLeft();
            if (res) Root = node.Parent;
        }

        while (!node.IsLeaf())
            if (node.Left != null &&
                (node.Right == null || _priorityComparer.Compare(node.Left.Value, node.Right.Value) < 0))
                node.Left.RotateRight();
            else
                node.Right!.RotateLeft();

        if (node.Parent!.Left == node) node.Parent.Left = null;
        else node.Parent.Right = null;

        return true;
    }

    // TODO: not done.
    public bool ChangePriority(TKey key, TPriority newPriority)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        if (newPriority == null) throw new ArgumentNullException(nameof(newPriority));

        var node = Root.Find(key);

        if (node == null) return false;
        var oldPriority = node.Value;
        node.Value = newPriority;

        if (_priorityComparer.Compare(newPriority, oldPriority) < 0)
            MoveUp(node);
        else
            MoveDown(node);

        return true;
    }

    // TODO: not done.
    private void MoveUp(BinaryTreeNode<TKey, TPriority> node)
    {
        while (true)
        {
            if (_priorityComparer.Compare(node.Value, node.Parent!.Value) >= 0) return;

            if (node.Parent.Left == node) node.RotateRight();
            else node.RotateLeft();
        }
    }

    // TODO: not done.
    private void MoveDown(BinaryTreeNode<TKey, TPriority> node)
    {
        if (node.IsLeaf()) return;

        var highestPriorityChild = node.Left;
        if (highestPriorityChild == null ||
            (node.Right != null && _priorityComparer.Compare(node.Right.Value, highestPriorityChild.Value) < 0))
            highestPriorityChild = node.Right;

        if (_priorityComparer.Compare(highestPriorityChild!.Value, node.Value) < 0) return;

        if (highestPriorityChild.Parent!.Left == highestPriorityChild)
            highestPriorityChild.RotateRight();
        else
            highestPriorityChild.RotateLeft();
    }

    public bool Contains(TKey key)
    {
        return Root.Find(key) != null;
    }

    public TKey Min()
    {
        if (Root == null) throw new InvalidOperationException();
        var node = Root;
        while (node.Left != null) node = node.Left;
        return node.Key;
    }

    public TKey Max()
    {
        if (Root == null) throw new InvalidOperationException();
        var node = Root;
        while (node.Right != null) node = node.Right;
        return node.Key;
    }
}