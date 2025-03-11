using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    // Graph class implements ICloneable to allow deep copying
    public class Graph : ICloneable
    {
        // Private field to store graph ID
        private int id;

        // Dictionary to store vertices, with int keys and Vertex objects as values
        public Dictionary<int, Vertex> vertices;

        // Dictionary to store edges, with int keys and Edge objects as values
        public Dictionary<int, Edge> edges;

        // Property to get or set the graph's ID
        public int Id
        {
            get { return id; } // Get method returns the graph ID
            set { id = value; } // Set method assigns a value to the graph ID
        }

        // Constructor initializes graph with a given ID and empty dictionaries for vertices and edges
        public Graph(int id)
        {
            Id = id; // Assign the provided ID to the graph
            vertices = new Dictionary<int, Vertex>(); // Initialize the vertices dictionary
            edges = new Dictionary<int, Edge>(); // Initialize the edges dictionary
        }

        /*
         * Method to display the graph by drawing all vertices and edges
         * Takes a Graphics object 'g' to perform the drawing
         */
        public void display(Graphics g)
        {
            // Check if there are any vertices to draw
            if (vertices.Count != 0)
            {
                // Iterate through all vertices and draw each one
                foreach (KeyValuePair<int, Vertex> v in vertices)
                {
                    v.Value.drawing(g); // Call the drawing method of each Vertex
                }
            }

            // Check if there are any edges to draw
            if (edges.Count != 0)
            {
                // Iterate through all edges and draw each one
                foreach (KeyValuePair<int, Edge> e in edges)
                {
                    e.Value.drawing(g); // Call the drawing method of each Edge
                }
            }
        }

        /*
         * Method to create a deep copy (clone) of the Graph object
         * Returns a new Graph instance with copies of all vertices and edges
         */

        public object Clone( )
        {
            // Create a copy of the Graph object.
            Graph clone = (Graph)this.MemberwiseClone();

            // Deep copy vertices.
            clone.vertices = new Dictionary<int, Vertex>();
            // Copy vertex values from original graph to cloned graph.
            foreach (KeyValuePair<int, Vertex> v in this.vertices)
            {
                // Create a new Vertex object and copy its properties.
                Vertex newVertex = new Vertex(v.Key, v.Value.X_coordinate, v.Value.Y_coordinate);

                // Add the cloned Vertex to the new dictionary.
                clone.vertices.Add(v.Key, newVertex);
            }

            // Deep copy edges.
            clone.edges = new Dictionary<int, Edge>();
            // Copy edge values from original graph to cloned graph.
            foreach (KeyValuePair<int, Edge> e in this.edges)
            {
                // Create a new Edge object and copy its properties (assuming a constructor or properties to copy)
                Edge newEdge = new Edge(e.Key, e.Value.from_vertex, e.Value.to_vertex);

                // Add the cloned Edge to the new dictionary
                clone.edges.Add(e.Key, newEdge);
            }

            return clone;
        }
    }
}
