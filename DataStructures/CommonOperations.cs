using System.Runtime.InteropServices.ComTypes;

namespace DataStructures;

public static class CommonOperations
{
    // TODO: changes internal tree structure: fix.
    public static IEnumerable<BinaryTreeNode<TKey, TValue>> InorderTraversal<TKey, TValue>(
        this BinaryTreeNode<TKey, TValue>? root)
    {
        var current = root;
        while (current != null)
            if (current.Left == null)
            {
                yield return current;
                current = current.Right;
            }
            else
            {
                var pre = current.Left;
                while (pre.Right != null && pre.Right != current) pre = pre.Right;
                if (pre.Right == null)
                {
                    pre.Right = current;
                    current = current.Left;
                }
                else
                {
                    pre.Right = null;
                    yield return current;
                    current = current.Right;
                }
            }
    }

    // TODO: changes internal tree structure: fix.
    public static IEnumerable<BinaryTreeNode<TKey, TValue>> PreorderTraversal<TKey, TValue>(
        this BinaryTreeNode<TKey, TValue>? root)
    {
        while (root != null)
            if (root.Left == null)
            {
                yield return root;
                root = root.Right;
            }
            else
            {
                var current = root.Left;
                while (current.Right != null && current.Right != root) current = current.Right;

                if (current.Right == root)
                {
                    current.Right = null;
                    root = root.Right;
                }
                else
                {
                    yield return root;
                    current.Right = root;
                    root = root.Left;
                }
            }
    }

    public static IEnumerable<BinaryTreeNode<TKey, TValue>> PostorderTraversal<TKey, TValue>(
        this BinaryTreeNode<TKey, TValue>? root)
    {
        if (root == null) yield break;

        var stack1 = new Stack<BinaryTreeNode<TKey, TValue>>();
        var stack2 = new Stack<BinaryTreeNode<TKey, TValue>>();

        stack1.Push(root);

        while (stack1.Count != 0)
        {
            var temp = stack1.Pop();
            stack2.Push(temp);
            if (temp.Left != null) stack1.Push(temp.Left);
            if (temp.Right != null) stack1.Push(temp.Right);
        }

        while (stack2.Count != 0) yield return stack2.Pop();
    }

    public static bool IsRoot<TKey, TValue>(this BinaryTreeNode<TKey, TValue> x)
    {
        return x.Parent == null;
    }

    public static bool IsLeaf<TKey, TValue>(this BinaryTreeNode<TKey, TValue> x)
    {
        return x.Left == null && x.Right == null;
    }

    /// <summary>
    ///     Performs a right rotation of a binary tree node.
    /// </summary>
    /// <param name="x">Tree node to rotate.</param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TPriority"></typeparam>
    /// <returns>True if the root of the tree should be updated to x, false otherwise.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool RotateRight<TKey, TPriority>(this BinaryTreeNode<TKey, TPriority> x)
    {
        var res = true;

        if (x.IsRoot()) throw new ArgumentException(nameof(x));
        var y = x.Parent!;
        if (y.Left != x) throw new ArgumentException(nameof(x));
        var p = y.Parent;

        if (p != null)
        {
            if (p.Left == y) p.Left = x;
            else p.Right = x;
            res = false;
        }
        else
        {
            x.Parent = null;
        }

        y.Left = x.Right;
        x.Right = y;

        return res;
    }

    /// <summary>
    ///     Performs a left rotation of a binary tree node.
    /// </summary>
    /// <param name="x"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TPriority"></typeparam>
    /// <returns>True if the root of the tree should be updated to x, false otherwise.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool RotateLeft<TKey, TPriority>(this BinaryTreeNode<TKey, TPriority> x)
    {
        var res = true;

        if (x.IsRoot()) throw new ArgumentException(nameof(x));
        var y = x.Parent!;
        if (y.Right != x) throw new ArgumentException(nameof(x));
        var p = y.Parent;

        if (p != null)
        {
            if (p.Left == y) p.Left = x;
            else p.Right = x;
            res = false;
        }
        else
        {
            x.Parent = null;
        }

        y.Right = x.Left;
        x.Left = y;

        return res;
    }

    public static BinaryTreeNode<TKey, TValue>? Find<TKey, TValue>(this BinaryTreeNode<TKey, TValue>? root, TKey key)
    {
        while (true)
        {
            if (root == null) return null;
            switch (Comparer<TKey>.Default.Compare(key, root.Key))
            {
                case 0:
                    return root;
                case < 0:
                    root = root.Left;
                    continue;
                default:
                    root = root.Right;
                    continue;
            }
        }
    }

    /// <summary>
    ///     Recursive method.
    /// </summary>
    /// <param name="node"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    internal static int Height<TKey, TValue>(BinaryTreeNode<TKey, TValue>? node)
    {
        return node == null ? -1 : Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }
}