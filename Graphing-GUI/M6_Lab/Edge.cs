using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    // Represents an edge in a graph, connecting two vertices.
    public class Edge
    {
        // Private fields to store the edge ID and the vertices it connects.
        private int id; // Unique identifier for the edge.
        private Vertex from; // Starting vertex.
        private Vertex to;   // Ending vertex.

        // Property for accessing and modifying the edge ID.
        public int edgeId
        {
            get { return id; } // Returns the edge ID.
            set { id = value; } // Sets the edge ID.
        }

        // Property for accessing and modifying the starting vertex.
        public Vertex from_vertex
        {
            get { return from; } // Returns the starting vertex.
            set { from = value; } // Sets the starting vertex.
        }

        // Property for accessing and modifying the ending vertex.
        public Vertex to_vertex
        {
            get { return to; } // Returns the ending vertex.
            set { to = value; } // Sets the ending vertex.
        }

        // Constructor to initialize an Edge with an ID, starting vertex, and ending vertex.
        public Edge(int id, Vertex from, Vertex to)
        {
            this.id = id;   // Assigns the edge ID.
            this.from = from; // Assigns the starting vertex.
            this.to = to;     // Assigns the ending vertex.
        }

        // Method to draw the edge as a line with an arrow on a Graphics object.
        public void drawing(Graphics g)
        {
            Pen pen = new Pen(Color.Black); // Creates a black pen for drawing.

            // Draw line between the 'from' vertex and 'to' vertex.
            g.DrawLine(pen, from_vertex.X_coordinate, from_vertex.Y_coordinate, to_vertex.X_coordinate, to_vertex.Y_coordinate);

            /*
             * Draw an arrowhead at the 'to' vertex.
             * The arrow is calculated using trigonometry by creating two points at an angle from the line's direction.
             */
            Point direction = new Point(to_vertex.X_coordinate - from_vertex.X_coordinate, to_vertex.Y_coordinate - from_vertex.Y_coordinate); // Calculate direction.
            double angle = Math.Atan2(direction.Y, direction.X); // Calculate angle of the line.
            double arrowLength = 10; // Length of the arrowhead.

            // Calculate the two points forming the arrowhead.
            Point point1 = new Point(
                (int)(to_vertex.X_coordinate - arrowLength * Math.Cos(angle + Math.PI / 6)),
                (int)(to_vertex.Y_coordinate - arrowLength * Math.Sin(angle + Math.PI / 6))
            );
            Point point2 = new Point(
                (int)(to_vertex.X_coordinate - arrowLength * Math.Cos(angle - Math.PI / 6)),
                (int)(to_vertex.Y_coordinate - arrowLength * Math.Sin(angle - Math.PI / 6))
            );

            // Draw the two lines forming the arrowhead.
            g.DrawLine(pen, to_vertex.X_coordinate, to_vertex.Y_coordinate, point1.X, point1.Y);
            g.DrawLine(pen, to_vertex.X_coordinate, to_vertex.Y_coordinate, point2.X, point2.Y);
        }
    }
}
