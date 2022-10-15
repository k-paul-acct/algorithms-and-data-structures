using DataStructures;

var graph = new Graph<string>();

graph.AddNode("a");
graph.AddNode("b");
graph.AddNode("c");
graph.AddNode("d");
graph.AddNode("e");
graph.AddNode("f");
graph.AddNode("g");

graph.AddEdge("a", "b");
graph.AddEdge("b", "a");

graph.AddEdge("a", "c");
graph.AddEdge("c", "a");

graph.AddEdge("a", "d");
graph.AddEdge("d", "a");

graph.AddEdge("b", "c");
graph.AddEdge("c", "b");

graph.AddEdge("b", "e");
graph.AddEdge("e", "b");

graph.AddEdge("c", "d");
graph.AddEdge("d", "c");

graph.AddEdge("c", "e");
graph.AddEdge("e", "c");

graph.AddEdge("c", "f");
graph.AddEdge("f", "c");

graph.AddEdge("d", "f");
graph.AddEdge("f", "d");

graph.AddEdge("e", "f");
graph.AddEdge("f", "e");

graph.AddEdge("e", "g");
graph.AddEdge("g", "e");

graph.AddEdge("f", "g");
graph.AddEdge("g", "f");

// var path = graph.Dijkstra(a, g);

foreach (var x in graph.Neighbors("c")) Console.Write($"{x}, ");
Console.WriteLine();