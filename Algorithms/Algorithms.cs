using DataStructures;

namespace Algorithms;

public static class Algorithms
{
    /**
     * Returns the list of nodes that form the path from startNode to endNode.
     */
    public static ICollection<Node> Dijkstra(this Graph graph, Node startNode, Node endNode)
    {
        var queue = new HashSet<Node>();
        var distances = new Dictionary<Node, double>();
        var parents = new Dictionary<Node, Node?>();

        foreach (var n in graph.Nodes)
        {
            queue.Add(n);
            parents.Add(n, null);
            distances.Add(n, double.PositiveInfinity);
        }

        distances[startNode] = 0;

        while (queue.Count != 0)
        {
            var n = distances.Where(x => queue.Contains(x.Key)).MinBy(x => x.Value).Key;
            // var n = distances.MinBy(x => x.Value).Key;
            queue.Remove(n);
            if (n == endNode) break;

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
    }
}