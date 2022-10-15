using System.Diagnostics.CodeAnalysis;

namespace DataStructures;

/// <summary>
/// Graph data structure.
/// </summary>
/// <typeparam name="T">type of nodes in the graph.</typeparam>
public class Graph<T> where T : notnull
{
    /// <summary>
    /// The number of nodes in the graph.
    /// </summary>
    public int Count { get; private set; }

    public IEnumerable<T> Nodes => _nodes.Keys;
    private readonly HashSet<Edge<T>> _edges = new();
    private readonly Dictionary<T, List<T>> _nodes = new();

    /// <summary>
    /// Adds the specified node to the graph.
    /// </summary>
    /// <param name="node">node to add.</param>
    /// <returns>true if the node has been added, false if it is already in the graph.</returns>
    public bool AddNode(T node)
    {
        if (_nodes.ContainsKey(node)) return false;
        _nodes.Add(node, new List<T>());
        Count++;
        return true;
    }

    /// <summary>
    /// Adds directed edge from fromNode to toNode.
    /// </summary>
    /// <param name="fromNode">start node of edge.</param>
    /// <param name="toNode">end node of edge.</param>
    /// <returns>true if both of specified nodes exist in the graph and edge was added, false otherwise.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool AddEdge(T fromNode, T toNode)
    {
        if (!_nodes.ContainsKey(fromNode) || !_nodes.ContainsKey(toNode) ||
            _nodes[fromNode].Contains(toNode)) return false;
        _nodes[fromNode].Add(toNode);
        return true;
    }

    /// <summary>
    /// Removes the specified node with all outgoing and incoming edges from the graph.
    /// </summary>
    /// <param name="node">node to delete.</param>
    /// <returns>true if node was found and deleted, false otherwise.</returns>
    public bool RemoveNode(T node)
    {
        return _nodes.Remove(node);
    }

    public IEnumerable<Edge<T>> AdjacencyList(T node)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns all neighbors of the specified node.
    /// </summary>
    /// <param name="node">node whose neighbors need to be returned.</param>
    /// <returns><see cref="IEnumerable{T}"/> of found nodes.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> Neighbors(T node)
    {
        return !_nodes.ContainsKey(node) ? new List<T>() : _nodes[node];
    }
}