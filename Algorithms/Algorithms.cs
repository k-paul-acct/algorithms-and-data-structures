using DataStructures;

namespace Algorithms;

public static class Algorithms
{
    /*/// <summary>
    ///     Returns the <see cref="IEnumerable{T}"/> that form the path with min weight from startNode to endNode.
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="startNode">start node for algorithm.</param>
    /// <param name="endNode">end node for algorithm.</param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Dijkstra<TSource>(this Graph<TSource> graph, TSource startNode, TSource endNode)
        where TSource : notnull 
    {
        var queue = new HashSet<TSource>();
        var distances = new Dictionary<TSource, double>();
        var parents = new Dictionary<TSource, TSource?>();

        foreach (var n in graph.Nodes)
        {
            queue.Add(n);
            parents.Add(n, default);
            distances.Add(n, double.PositiveInfinity);
        }

        distances[startNode] = 0;

        while (queue.Count != 0)
        {
            var n = distances.Where(x => queue.Contains(x.Key)).MinBy(x => x.Value).Key;
            queue.Remove(n);
            if (n.Equals(endNode)) break;

            foreach (var e in graph.AdjacencyList(n))
            {
                var alt = distances[n] + e.Weight;
                if (distances[e.EndNode] <= alt) continue;
                distances[e.EndNode] = alt;
                parents[e.EndNode] = n;
            }
        }

        var s = new List<Node>();
        var u = endNode;

        if (parents[u] != null || u == startNode)
            while (parents[u!] != null)
            {
                s.Add(u!);
                u = parents[u!];
            }

        s.Add(startNode);
        s.Reverse();

        return s;
    }*/

    /// <summary>
    ///     Preorder depth first search on the <see cref="Graph{TSource}" />.
    /// </summary>
    /// <param name="graph">graph for algorithm.</param>
    /// <param name="fromNode">start node for searching.</param>
    /// <returns><see cref="IEnumerable{TSource}" /> in proper order.</returns>
    public static IEnumerable<TSource> DepthFirstSearch<TSource>(this Graph<TSource> graph, TSource fromNode)
        where TSource : notnull
    {
        var marked = graph.Nodes.ToDictionary(x => x, _ => false);
        var stack = new Stack<TSource>();
        stack.Push(fromNode);
        while (stack.Count > 0)
        {
            var n = stack.Pop();
            if (marked[n]) continue;
            yield return n;
            marked[n] = true;
            foreach (var x in graph.Neighbors(n))
            {
                if (marked[x]) continue;
                stack.Push(x);
            }
        }
    }

    /// <summary>
    ///     Breadth first search on the <see cref="Graph{TSource}" />.
    /// </summary>
    /// <param name="graph">graph for algorithm.</param>
    /// <param name="fromNode">start node for searching.</param>
    /// <returns><see cref="IEnumerable{TSource}" /> in proper order.</returns>
    public static IEnumerable<TSource> BreadthFirstSearch<TSource>(this Graph<TSource> graph, TSource fromNode)
        where TSource : notnull
    {
        var marked = graph.Nodes.ToDictionary(x => x, _ => false);
        var queue = new Queue<TSource>();
        queue.Enqueue(fromNode);
        while (queue.Count > 0)
        {
            var n = queue.Dequeue();
            if (marked[n]) continue;
            yield return n;
            marked[n] = true;
            foreach (var x in graph.Neighbors(n))
            {
                if (marked[x]) continue;
                queue.Enqueue(x);
            }
        }
    }
}