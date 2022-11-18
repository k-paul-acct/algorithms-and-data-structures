namespace DataStructures;

public class BinaryTreeNode<TKey, TValue>
{
    private BinaryTreeNode<TKey, TValue>? _left;
    private BinaryTreeNode<TKey, TValue>? _right;

    public BinaryTreeNode(
        TKey key, TValue value,
        BinaryTreeNode<TKey, TValue>? left = null,
        BinaryTreeNode<TKey, TValue>? right = null)
    {
        Key = key;
        Value = value;
        Left = left;
        Right = right;
    }

    public BinaryTreeNode<TKey, TValue>? Left
    {
        get => _left;
        set
        {
            _left = value;
            if (_left != null) _left.Parent = this;
        }
    }

    public BinaryTreeNode<TKey, TValue>? Right
    {
        get => _right;
        set
        {
            _right = value;
            if (_right != null) _right.Parent = this;
        }
    }

    public BinaryTreeNode<TKey, TValue>? Parent { get; set; }

    public TKey Key { get; init; }
    public TValue Value { get; internal set; }
}