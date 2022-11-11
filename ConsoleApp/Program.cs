using Algorithms;
using DataStructures;

var graph = new Graph<string>();

graph.AddNode("a");
graph.AddNode("b");
graph.AddNode("c");
graph.AddNode("d");
graph.AddNode("e");
graph.AddNode("f");
graph.AddNode("g");

graph.AddUndirectedEdge("a", "b");
graph.AddUndirectedEdge("a", "c");
graph.AddUndirectedEdge("a", "d");
graph.AddUndirectedEdge("b", "c");
graph.AddUndirectedEdge("b", "e");
graph.AddUndirectedEdge("c", "d");
graph.AddUndirectedEdge("c", "e");
graph.AddUndirectedEdge("c", "f");
graph.AddUndirectedEdge("d", "f");
graph.AddUndirectedEdge("e", "f");
graph.AddUndirectedEdge("e", "g");
graph.AddUndirectedEdge("f", "g");

// var path = graph.Dijkstra(a, g);

foreach (var x in graph.DepthFirstSearch("a")) Console.Write($"{x} -> ");
Console.WriteLine();

var graph2 = new Graph<int>();

graph2.AddNode(0);
graph2.AddNode(1);
graph2.AddNode(2);
graph2.AddNode(3);
graph2.AddNode(4);
graph2.AddNode(5);
graph2.AddNode(6);
graph2.AddNode(7);
graph2.AddNode(8);
graph2.AddNode(9);

graph2.AddUndirectedEdge(0, 1);
graph2.AddUndirectedEdge(0, 2);
graph2.AddUndirectedEdge(1, 2);
graph2.AddUndirectedEdge(1, 3);
graph2.AddUndirectedEdge(1, 4);
graph2.AddUndirectedEdge(3, 5);
graph2.AddUndirectedEdge(5, 6);
graph2.AddUndirectedEdge(5, 7);
graph2.AddUndirectedEdge(5, 8);
graph2.AddUndirectedEdge(7, 8);
graph2.AddUndirectedEdge(8, 9);

foreach (var x in graph2.BreadthFirstSearch(0)) Console.Write($"{x} -> ");
Console.WriteLine();

var graph3 = new Graph<int>();

graph3.AddNode(0);
graph3.AddNode(1);
graph3.AddNode(2);
graph3.AddNode(3);
graph3.AddNode(4);
graph3.AddNode(5);

graph3.AddUndirectedEdge(0, 1);
graph3.AddUndirectedEdge(0, 2);
graph3.AddUndirectedEdge(0, 3);
graph3.AddUndirectedEdge(0, 4);
graph3.AddUndirectedEdge(1, 5);
graph3.AddUndirectedEdge(2, 4);
graph3.AddUndirectedEdge(3, 5);

foreach (var x in graph3.BreadthFirstSearch(0)) Console.Write($"{x} -> ");
Console.WriteLine();