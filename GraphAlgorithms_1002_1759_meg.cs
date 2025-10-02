// 代码生成时间: 2025-10-02 17:59:57
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheoryApp
{
    /// <summary>
    /// Represents a graph with nodes and edges.
    /// </summary>
    public class Graph
    {
        private readonly List<Node> nodes;
        private readonly List<Edge> edges;

        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public void AddNode(Node node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (nodes.Any(n => n.Name == node.Name)) throw new InvalidOperationException("A node with the same name already exists.");
            nodes.Add(node);
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        public void AddEdge(Edge edge)
        {
            if (edge == null) throw new ArgumentNullException(nameof(edge));
            if (!nodes.Any(n => n.Name == edge.Source.Name) || !nodes.Any(n => n.Name == edge.Destination.Name))
                throw new InvalidOperationException("Edge source or destination does not exist.");
            edges.Add(edge);
        }

        // Additional methods for traversing, searching, etc., can be added here.

        /// <summary>
        /// Represents a node in the graph.
        /// </summary>
        public class Node
        {
            public string Name { get; }

            public Node(string name)
            {
                Name = name;
            }
        }

        /// <summary>
        /// Represents a directed edge between two nodes in the graph.
        /// </summary>
        public class Edge
        {
            public Node Source { get; }
            public Node Destination { get; }
            public double Weight { get; }

            public Edge(Node source, Node destination, double weight)
            {
                Source = source ?? throw new ArgumentNullException(nameof(source));
                Destination = destination ?? throw new ArgumentNullException(nameof(destination));
                Weight = weight;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the Graph class.
            try
            {
                var graph = new Graph();

                var nodeA = new Graph.Node("A");
                var nodeB = new Graph.Node("B");
                var nodeC = new Graph.Node("C");

                graph.AddNode(nodeA);
                graph.AddNode(nodeB);
                graph.AddNode(nodeC);

                var edgeAB = new Graph.Edge(nodeA, nodeB, 1.0);
                var edgeBC = new Graph.Edge(nodeB, nodeC, 2.0);
                var edgeCA = new Graph.Edge(nodeC, nodeA, 3.0);

                graph.AddEdge(edgeAB);
                graph.AddEdge(edgeBC);
                graph.AddEdge(edgeCA);

                // You can implement traversal algorithms (e.g., BFS, DFS) here and use the graph.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}